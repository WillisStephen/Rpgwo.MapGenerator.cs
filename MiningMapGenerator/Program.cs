using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiningMapGenerator
{
    class Program
    {
        public static SortedList<int, int[,]> MiningMap = new SortedList<int, int[,]>();
        public static Random random = new Random();

        static void Main(string[] args)
        {
            Console.Write(Data.Title);
            Console.Write(Data.Info);
            Console.WriteLine("");

            IniReader.CheckConfigs();
            InitializeMap();
            CreateMiningMap();
            if (Confirmation("Edit world maps using the data above?"))
            {
                MapReader.GetMapFiles();
                MapReader.EditMaps();

                if(MapReader.newbMapFiles.Count > 0)
                {
                    if (Confirmation("Generate NewbIsland mining data?"))
                    {

                    }
                    else
                    {
                        return;
                    }
                }
            }
            else
            {
                if (MapReader.newbMapFiles.Count > 0)
                {
                    if (Confirmation("Generate NewbIsland mining data?"))
                    {

                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    return;
                }
            }
        }

        static void InitializeMap()
        {
            for(int i = 1; i < Data.worldLayers + 1; i++)
            {
                MiningMap[i] = new int[Data.mapSize, Data.mapSize];
            }
        }

        static void CreateMiningMap()
        {
            Console.WriteLine("World Size: " + Data.mapSize + " x " + Data.mapSize + " with " + Data.worldLayers + " layers");
            Console.WriteLine();
            int count = 0;
            int veinCount = 0;

            for (int i = 1; i < Data.worldLayers + 1; i++)
            {
                foreach (KeyValuePair<int, Ore> o in IniReader.Ores)
                {
                    int index = o.Key;
                    Ore ore = o.Value;

                    if (ore.layers.ContainsKey(i))
                    {
                        int spots = (int)(Data.worldSize * ((float)ore.layers[i].rarity * 0.01f));

                        for (int ii = 0; ii < spots; ii++)
                        {
                            int x = random.Next(0, Data.mapSize);
                            int y = random.Next(0, Data.mapSize);

                            MiningMap[i][x, y] = index;
                            count++;

                            if (ore.layers[i].veinChance > 0)
                            {
                                if (random.Next(0, 101) >= ore.layers[i].veinChance)
                                {
                                    int veinSize = random.Next(ore.layers[i].minVein, ore.layers[i].maxVein + 1);
                                    Vector2 direction = new Vector2(random.Next(-1, 1), random.Next(-1, 1));

                                    int spawnCount = CreateVein(index, veinSize, x, y, direction, i);
                                    spots -= spawnCount;
                                    count += spawnCount;
                                    veinCount++;
                                }
                            }
                        }
                    }

                    if(count <= 0)
                    {
                        Console.WriteLine("Layer: " + i + " - " + ore.name + " : " + count + " spawned");
                    }
                    else
                    {
                        Console.WriteLine("Layer: " + i + " - " + ore.name + " : " + count + " spawned : " + veinCount + " veins : " + ore.layers[i].rarity + "%");
                    }

                    count = 0;
                    veinCount = 0;
                }

                Console.WriteLine();
            }
        }

        static int CreateVein(int index, int veinSize, int x, int y, Vector2 direction, int layer)
        {
            int numSpawned = 0;
            int numToGo = veinSize;
            int locX = x;
            int locY = y;

            while(numToGo > 0)
            {
                numToGo--;

                if (locX + direction.x >= Data.mapSize || locX + direction.x < 0 || locX + direction.y >= Data.mapSize || locY + direction.y < 0)
                    continue;

                locX += direction.x;
                locY += direction.y;

                MiningMap[layer][locX, locY] = index;
                numSpawned++;
            }

            return numSpawned;
        }

        static bool Confirmation(string text)
        {
            ConsoleKey response;
            do
            {
                Console.Write(text + " (y or n) ");
                response = Console.ReadKey(false).Key;

                if (response != ConsoleKey.Enter)
                    Console.WriteLine();
            }
            while (response != ConsoleKey.Y && response != ConsoleKey.N);

            return (response == ConsoleKey.Y);
        }
    }
}

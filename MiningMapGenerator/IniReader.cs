using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiningMapGenerator
{
    public class IniReader
    {
        public static Dictionary<int, Ore> Ores = new Dictionary<int, Ore>();

        //Name Value
        public const string Name = "Name";

        //Layer Values - Syntax is  <int>, <int> --  Example: Rarity=1,50  meaning in Layer 1, 50% rarity
        public const string Rarity = "Rarity";
        public const string VeinChance = "VeinChance";
        public const string MinVein = "MinVein";
        public const string MaxVein = "MaxVein";

        //Newb Values
        public const string NewbRarity = "NewbRarity";
        public const string NewbVeinChance = "NewbVeinChance";
        public const string NewbMinVein = "NewbMinVein";
        public const string NewbMaxVein = "NewbMaxVein";
        //public const string NewbFile = "NewbFile";   // Used to declare the dungeon map being used for newb island mining.

        //Default Values
        public const string DefaultVeinChance = "DefaultVeinChance";
        public const string DefaultMinVein = "DefaultMinVein";
        public const string DefaultMaxVein = "DefaultMaxVein";

        public static void CheckConfigs()
        {
            if (!File.Exists(Data.configFile))
            {
                Console.WriteLine("ERROR: No Ore Config Found.");
                Console.WriteLine("Press any key to close.");
                Console.ReadKey();
                return;
            }

            if (!File.Exists(Data.worldFile))
            {
                Console.WriteLine("ERROR: No World.ini Found. Please make sure this is located in the server folder.");
                Console.WriteLine("Press any key to close.");
                Console.ReadKey();
                return;
            }

            ReadConfig();

            ReadWorld();
        }

        public static void ReadConfig()
        {

            int oreIndex = -1;

            StreamReader file = new StreamReader(Data.configFile);
            string line;

            while ((line = file.ReadLine()) != null)
            {
                if (!line.StartsWith(";"))
                {
                    string[] splitLine = line.Split('=');

                    switch (splitLine[0])
                    {
                        case DefaultVeinChance:
                            Data.defaultVeinChance = Convert.ToInt32(splitLine[1]);
                            break;
                        case DefaultMinVein:
                            Data.defaultMinVein = Convert.ToInt32(splitLine[1]);
                            break;
                        case DefaultMaxVein:
                            Data.defaultMaxVein = Convert.ToInt32(splitLine[1]);
                            break;
                        case Name:
                            oreIndex++;
                            Ores[oreIndex] = new Ore();
                            Ores[oreIndex].layers = new Dictionary<int, LayerData>();
                            Ores[oreIndex].name = splitLine[1];
                            break;
                        case Rarity:
                            string[] splitLayer = splitLine[1].Split(',');
                            if(splitLayer.Length > 1)
                            {
                                Ores[oreIndex].layers[Convert.ToInt32(splitLayer[0])] = new LayerData
                                {
                                    rarity = Convert.ToDecimal(splitLayer[1])
                                };
                            }
                            else
                            {
                                Ores[oreIndex].defaultRarity = Convert.ToDecimal(splitLayer[0]);
                            }
                            break;
                        case VeinChance:
                            splitLayer = splitLine[1].Split(','); 
                            if (splitLayer.Length > 1)
                            {
                                Ores[oreIndex].layers[Convert.ToInt32(splitLayer[0])].veinChance = Convert.ToInt32(splitLayer[1]);
                            }
                            else
                            {
                                Ores[oreIndex].defaultVeinChance = Convert.ToInt32(splitLayer[0]);
                            }
                            break;
                        case MinVein:
                            splitLayer = splitLine[1].Split(','); 
                            if (splitLayer.Length > 1)
                            {
                                Ores[oreIndex].layers[Convert.ToInt32(splitLayer[0])].minVein = Convert.ToInt32(splitLayer[1]);
                            }
                            else
                            {
                                Ores[oreIndex].defaultMinVein = Convert.ToInt32(splitLayer[0]);
                            }
                            break;
                        case MaxVein:
                            splitLayer = splitLine[1].Split(','); 
                            if (splitLayer.Length > 1)
                            {
                                Ores[oreIndex].layers[Convert.ToInt32(splitLayer[0])].maxVein = Convert.ToInt32(splitLayer[1]);
                            }
                            else
                            {
                                Ores[oreIndex].defaultMaxVein = Convert.ToInt32(splitLayer[0]);
                            }
                            break;
                        case NewbRarity:
                            Ores[oreIndex].newbRarity = Convert.ToInt32(splitLine[1]);
                            break;
                        case NewbVeinChance:
                            Ores[oreIndex].newbVeinChance = Convert.ToInt32(splitLine[1]);
                            break;
                        case NewbMinVein:
                            Ores[oreIndex].newbMinVein = Convert.ToInt32(splitLine[1]);
                            break;
                        case NewbMaxVein:
                            Ores[oreIndex].newbMaxVein = Convert.ToInt32(splitLine[1]);
                            break;
                        //case NewbFile:
                        //    MapReader.newbMapFiles.Add(splitLine[1]);
                        //    break;
                    }
                }
            }
        }

        public static void ReadWorld()
        {
            const string MapSize = "MapSize";
            const string WorldDepth = "WorldDepth";

            StreamReader file = new StreamReader(Data.worldFile);
            string line;

            while ((line = file.ReadLine()) != null)
            {
                if (!line.StartsWith(";"))
                {
                    string[] splitLine = line.Split('=');

                    switch (splitLine[0])
                    {
                        case MapSize:
                            Data.mapSize = Convert.ToInt32(splitLine[1]);
                            Data.worldSize = Data.mapSize * Data.mapSize;
                            break;
                        case WorldDepth:
                            Data.worldLayers = Convert.ToInt32(splitLine[1]);
                            break;
                    }
                }
            }

        }
    }
}

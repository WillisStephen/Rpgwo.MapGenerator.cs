using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiningMapGenerator
{
    public class MapReader
    {
        public static List<string> worldMapFiles = new List<string>();
        public static List<string> newbMapFiles = new List<string>();
        public static byte[] Header = new byte[30];
        public static MiningData[] mapData = new MiningData[40000];
        public static byte[] Footer = new byte[2132];
        public static string dir;
        public static string mapDir;

        public static void GetMapFiles()
        {
            dir = Directory.GetCurrentDirectory();
            mapDir = dir + "\\maps";
            if (!Directory.Exists(mapDir))
            {
                Console.WriteLine("ERROR: No maps folder found. Please make sure this is located in the server folder.");
                Console.WriteLine("Press any key to close.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Getting Map Files..");
            string[] files = Directory.GetFiles(mapDir);

            foreach (string f in files)
            {
                string subString = f.Substring(f.Length - 5);

                int layerNumber = Convert.ToInt32(subString.Substring(0, 1));
                string startsWith = f.Substring(mapDir.Length + 1, 3);

                if (layerNumber > 0 && layerNumber <= Data.worldLayers && startsWith == "map")
                {
                    worldMapFiles.Add(f);
                }
            }
        }

        public static void EditMaps()
        {
            foreach (string file in worldMapFiles)
            {
                int xOffset = Convert.ToInt32(file.Substring(mapDir.Length + 4, 4));
                int yOffset = Convert.ToInt32(file.Substring(mapDir.Length + 9, 4));
                int z = Convert.ToInt32(file.Substring(mapDir.Length + 14, 4));

                GetMapData(xOffset, yOffset, z);
                ReadMapFile(file);
                OverwriteMapFile(file);
            }
        }

        public static void GetMapData(int xOffset, int yOffset, int z)
        {
            int index = 0;
            Random random = new Random();

            for (int x = 0; x < 200; x++)
            {
                for (int y = 0; y < 200; y++)
                {
                    mapData[index].index = (byte)Program.MiningMap[z][x + xOffset, y + yOffset];
                    mapData[index].random = (byte)random.Next(0, 5);
                    index++;
                }
            }
        }

        public static void ReadMapFile(string file)
        {
            using (BinaryReader reader = new BinaryReader(File.OpenRead(file)))
            {
                while (reader.BaseStream.Position != reader.BaseStream.Length)
                {
                    Header = reader.ReadBytes(30);
                    _ = reader.ReadBytes(80000);
                    _ = reader.ReadBytes(40000);
                    Footer = reader.ReadBytes(2132);
                }
            }
        }

        public static void OverwriteMapFile(string file)
        {
            using (BinaryWriter writer = new BinaryWriter(new FileStream(file, FileMode.Create, FileAccess.Write)))
            {
                writer.Write(Header);

                foreach (MiningData m in mapData)
                {
                    writer.Write(m.index);
                    writer.Write(m.random);
                }

                for(int i = 0; i < 40000; i++)
                {
                    writer.Write(false);
                }

                writer.Write(Footer);
            }
        }

    }
}

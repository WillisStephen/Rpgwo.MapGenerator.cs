using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiningMapGenerator
{
    public class Data
    {
        public static string Title = "RPGWO Map Generator";

        public static string titleAscii = @"
 ██████╗ ██████╗  ██████╗ ██╗    ██╗ ██████╗ 
 ██╔══██╗██╔══██╗██╔════╝ ██║    ██║██╔═══██╗
 ██████╔╝██████╔╝██║  ███╗██║ █╗ ██║██║   ██║                     Created by Zodiak
 ██╔══██╗██╔═══╝ ██║   ██║██║███╗██║██║   ██║ 
 ██║  ██║██║     ╚██████╔╝╚███╔███╔╝╚██████╔╝
 ╚═╝  ╚═╝╚═╝      ╚═════╝  ╚══╝╚══╝  ╚═════╝ ";

        public static string titleAscii2 = @"
 ███╗   ███╗ █████╗ ██████╗      ██████╗ ███████╗███╗   ██╗███████╗██████╗  █████╗ ████████╗ ██████╗ ██████╗ 
 ████╗ ████║██╔══██╗██╔══██╗    ██╔════╝ ██╔════╝████╗  ██║██╔════╝██╔══██╗██╔══██╗╚══██╔══╝██╔═══██╗██╔══██╗
 ██╔████╔██║███████║██████╔╝    ██║  ███╗█████╗  ██╔██╗ ██║█████╗  ██████╔╝███████║   ██║   ██║   ██║██████╔╝
 ██║╚██╔╝██║██╔══██║██╔═══╝     ██║   ██║██╔══╝  ██║╚██╗██║██╔══╝  ██╔══██╗██╔══██║   ██║   ██║   ██║██╔══██╗
 ██║ ╚═╝ ██║██║  ██║██║         ╚██████╔╝███████╗██║ ╚████║███████╗██║  ██║██║  ██║   ██║   ╚██████╔╝██║  ██║
 ╚═╝     ╚═╝╚═╝  ╚═╝╚═╝          ╚═════╝ ╚══════╝╚═╝  ╚═══╝╚══════╝╚═╝  ╚═╝╚═╝  ╚═╝   ╚═╝    ╚═════╝ ╚═╝  ╚═╝";

        public static string Selection0 = " 1) Generate Full World";
        public static string Selection1 = " 2) Generate Surface Maps";
        public static string Selection2 = " 3) Generate Mining Maps";
        public static string Selection3 = " 4) Generate a Floating Map";
        public static string Selection4 = " 5) Edit Mining Map Data";

        public static string configFile = @"OreConfig.ini";
        public static string worldFile = @"World.ini";

        public static int mapSize = 0;
        public static int worldSize = 0;
        public static int worldLayers = 0;

        public static int defaultVeinChance = 0;
        public static int defaultMinVein = 0;
        public static int defaultMaxVein = 0;
    }

    public class Ore
    {
        public int index;
        public string name;
        public Dictionary<int, LayerData> layers;
        public decimal defaultRarity;
        public int defaultVeinChance;
        public int defaultMinVein;
        public int defaultMaxVein;
        
        public int newbRarity;
        public int newbVeinChance;
        public int newbMinVein;
        public int newbMaxVein;
    }

    public class LayerData
    {
        public decimal rarity;
        public int veinChance;
        public int minVein;
        public int maxVein;
    }


    public class Vector2
    {
        public int x;
        public int y;

        public Vector2(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}

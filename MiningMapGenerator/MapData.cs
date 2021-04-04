using static System.Math;

namespace MiningMapGenerator
{
    public struct HeaderData
    {
        /// <summary>
        /// Size of the sector. 
        /// Hard coded to be xSize = 200 && ySize = 200
        /// </summary>
        public ushort xSize;
        public ushort ySize;

        /// <summary>
        /// Both X and Y
        /// World position is in multiples of the x and y Sizes. (Default 200)
        /// </summary>
        public ushort worldXPosition;
        public ushort worldYPosition;

        /// <summary>
        /// Z level of the map.
        /// 0 = Surface
        /// 1-99 is Mining Map
        /// 100+ is Floating Map
        /// </summary>
        public ushort worldZPosition;

        /// <summary>
        /// This is used for which sectors are attached. In the order below (Starting at the top left and going clockwise)
        /// -1, -1 | -1, 0 | -1, 1 | 0, -1 | 0, 0 | 0, 1 | 1, -1 | 1, 0 | 1, 1
        /// </summary>
        public ushort[] connectionGrid;

        /// <summary>
        /// This is used in place of a bool due to saving size.
        /// ushort.MinValue = False
        /// ushort.MaxValue = True
        /// </summary>
        public ushort surfaceFlag;
    }

    public struct ElevationData
    {
        /// <summary>
        /// Array size = xSize * ySize
        /// </summary>
        public byte[] data;
    }

    public struct WaterData
    {
        /// <summary>
        /// Array size = xSize * ySize
        /// </summary>
        public byte[] data;
    }

    public struct GrassData
    {
        /// <summary>
        /// Array size = xSize * ySize
        /// </summary>
        public byte[] data;
    }

    public struct OreIndex
    {
        public byte index;
        public byte random;
    }

    public struct MiningData
    {
        /// <summary>
        /// Array size = xSize * ySize
        /// </summary>
        public OreIndex[] data;
    }

    public struct MinedData
    {
        /// <summary>
        /// Array size = xSize * ySize
        /// </summary>
        public bool[] data;
    }

    public struct LandOwnerData
    {
        /// <summary>
        /// Array size = (Math.Floor(xSize / 20) + 1) * (Math.Floor(ySize / 20) + 1) * 214
        /// </summary>
        public byte[] data;
    }
    
    public struct MonsterSpawnData
    {
        /// <summary>
        /// Array size = Math.Ceiling(xSize / 50) * Math.Ceiling(ySize / 50) * 133
        /// </summary>
        public byte[] data;
    }

}

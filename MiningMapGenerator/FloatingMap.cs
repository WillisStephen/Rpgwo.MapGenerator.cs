using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiningMapGenerator
{
    public struct FloatingMapSurface
    {
        public HeaderData header;
        public ElevationData elevationData;
        public WaterData waterData;
        public LandOwnerData landOwnerData;
        public GrassData grassData;
        public MonsterSpawnData monsterSpawnData;
        public LandOwnerData landOwnerData2; // This will be a copy of the original.

        public FloatingMapSurface(int size)
        {
            header = new HeaderData();
            elevationData.data = new byte[size];
            waterData.data = new byte[size];
            landOwnerData.data = new byte[size];
            grassData.data = new byte[size];
            monsterSpawnData.data = new byte[size];
            landOwnerData2.data = new byte[size];
        }
    }

    public struct FloatingMapMining
    {
        public HeaderData header;
        public MiningData miningData;
        public MinedData minedData;
        public MonsterSpawnData monsterSpawnData;
        public LandOwnerData landOwnerData;

        public FloatingMapMining(int size)
        {
            header = new HeaderData();
            miningData.data = new OreIndex[size];
            minedData.data = new bool[size];
            monsterSpawnData.data = new byte[size];
            landOwnerData.data = new byte[size];
        }
    }
}

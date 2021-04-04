using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiningMapGenerator
{
    public struct MiningMap
    {
        public HeaderData header;
        public MiningData miningData;
        public MinedData minedData;
        public MonsterSpawnData monsterSpawnData;

        public MiningMap(int size)
        {
            header = new HeaderData();
            miningData.data = new OreIndex[size];
            minedData.data = new bool[size];
            monsterSpawnData.data = new byte[size];
        }
    }
}

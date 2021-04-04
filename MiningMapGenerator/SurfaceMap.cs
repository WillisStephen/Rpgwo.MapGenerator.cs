using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiningMapGenerator
{
    public struct SurfaceMap
    {
        public HeaderData header;
        public ElevationData elevationData;
        public WaterData waterData;
        public LandOwnerData landOwnerData;
        public GrassData grassData;
        public MonsterSpawnData monsterSpawnData;

        public SurfaceMap(int size)
        {
            header = new HeaderData();
            elevationData.data = new byte[size];
            waterData.data = new byte[size];
            landOwnerData.data = new byte[size];
            grassData.data = new byte[size];
            monsterSpawnData.data = new byte[size];
        }
    }
}

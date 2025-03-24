using System;
using System.Collections.Specialized;
using System.Numerics;

namespace MiniRPG.Logic.Map
{
    public class MapTile 
    {
        public MapTile(int x, int y, string tileTypeName, TileAirType tileAir = TileAirType.NormalOxygenLevel )
        {
            Location = new Vector3(x, y, 0);
            TileTypeName = tileTypeName;
            //TileTypeDirection = tileTypeDirection;
            TileAir = tileAir;
        }

        public Vector3 Location { get; private set; }
        public string TileTypeName { get; set; }
        //public int TileTypeDirection { get; set; }
        public TileAirType TileAir { get; set; }
        public bool HasAction { get; set; }
        public bool IsOpen { get; set; }
        public void Action()
        {
            if (HasAction)
            {
                IsOpen = !IsOpen;
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public enum TileAirType
        {
            NormalOxygenLevel,
            Vacuum,
            PoisonGas
        }
    }
}

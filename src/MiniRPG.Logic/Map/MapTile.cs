using System.Collections.Specialized;
using System.Numerics;

namespace MiniRPG.Logic.Map
{
    public class MapTile
    {
        public MapTile(int x, int y, string tileType, string tileAir)
        {
            this.Location = new Vector3(x, y, 0);
            TileType = tileType;
            TileAir = tileAir;
        }

        public Vector3 Location { get; private set; }
        public string TileType { get; set; }
        public string TileAir { get; set; } = null;
    }
}

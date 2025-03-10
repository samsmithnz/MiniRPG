using System.Collections.Generic;
using System.Numerics;

namespace MiniRPG.Logic
{
    public class Character
    {
        public int Life { get; set; } = 1;
        public Vector3 Location { get; set; }
        public List<Vector3> AvailableMoves { get; set; }
        public bool NorthMoveAvailable { get; set; }
        public bool EastMoveAvailable { get; set; }
        public bool SouthMoveAvailable { get; set; }
        public bool WestMoveAvailable { get; set; }

        public Character(Vector3 location)
        {
            Location = location;
        }

    }
}

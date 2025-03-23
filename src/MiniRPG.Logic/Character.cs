using MiniRPG.Logic.Map;
using System.Collections.Generic;
using System.Numerics;

namespace MiniRPG.Logic
{
    public class Character
    {
        public int Life { get; set; } = 1;
        public Vector3 Location { get; set; }
        public CharacterAction NorthMove { get; set; }
        public CharacterAction EastMove { get; set; }
        public CharacterAction SouthMove { get; set; }
        public CharacterAction WestMove { get; set; }

        public Character(Vector3 location)
        {
            Location = location;
        }

    }
}

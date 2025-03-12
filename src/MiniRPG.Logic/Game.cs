using System.Collections.Generic;
using System.Numerics;

namespace MiniRPG.Logic
{
    public class Game
    {

        public Level Level { get; set; }
        public Character Character { get; set; }
        public Game(int levelNumber)
        {
            Level = new Level(levelNumber);
            Character = new Character(Level.StartingLocation);
            GetAvailableMoves();
        }

        public void MoveCharacter(Vector3 newLocation)
        {
            // if it's a door, open the door instead of moving
            if (Level.Map[(int)newLocation.X, (int)newLocation.Z] == "d")
            {
                Level.Map[(int)newLocation.X, (int)newLocation.Z] = "D";
            }
            else
            {
                Character.Location = newLocation;
            }
            GetAvailableMoves();
        }

        public bool LevelIsComplete()
        {
            if (Character.Location == Level.EndingLocation)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string GetAvailableMoves()
        {
            List<Vector3> availableMoves = new List<Vector3>();

            bool levelIsComplete = LevelIsComplete();

            // Check all around the current character location for possible moves
            Vector3 NorthLocation = new Vector3(Character.Location.X, 0, Character.Location.Z + 1);
            Vector3 EastLocation = new Vector3(Character.Location.X + 1, 0, Character.Location.Z);
            Vector3 SouthLocation = new Vector3(Character.Location.X, 0, Character.Location.Z - 1);
            Vector3 WestLocation = new Vector3(Character.Location.X - 1, 0, Character.Location.Z);
            if (!levelIsComplete && CheckLocationForPossibleMove(NorthLocation))
            {
                availableMoves.Add(NorthLocation);
                Character.NorthMoveAvailable = true;
            }
            else
            {
                Character.NorthMoveAvailable = false;
            }
            if (!levelIsComplete && CheckLocationForPossibleMove(EastLocation))
            {
                availableMoves.Add(EastLocation);
                Character.EastMoveAvailable = true;
            }
            else
            {
                Character.EastMoveAvailable = false;
            }
            if (!levelIsComplete && CheckLocationForPossibleMove(SouthLocation))
            {
                availableMoves.Add(SouthLocation);
                Character.SouthMoveAvailable = true;
            }
            else
            {
                Character.SouthMoveAvailable = false;
            }
            if (!levelIsComplete && CheckLocationForPossibleMove(WestLocation))
            {
                availableMoves.Add(WestLocation);
                Character.WestMoveAvailable = true;
            }
            else
            {
                Character.WestMoveAvailable = false;
            }

            // Set the available moves for the character
            Character.AvailableMoves = availableMoves;

            return Character.Location.ToString();
        }

        private bool CheckLocationForPossibleMove(Vector3 location)
        {
            int x = (int)location.X;
            int z = (int)location.Z;
            if (x < 0 || x >= Level.Map.GetLength(0) || z < 0 || z >= Level.Map.GetLength(1))
            {
                return false;
            }
            else
            {
                if (Level.Map[(int)location.X, (int)location.Z] == "D" || Level.Map[(int)location.X, (int)location.Z] == "d")
                {
                    // it's a door, with two states. "D" is closed, "d" is open.
                    return true;
                }
                else if (Level.Map[(int)location.X, (int)location.Z] == "")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

    }
}

using System.Collections.Generic;
using System.Numerics;

namespace MiniRPG.Logic
{
    public class Game
    {
        public string[,] Map { get; set; }
        public Character Character { get; set; }
        public Game(string[,] map, Vector3 startingLocation)
        {
            Map = map;
            Character = new Character(startingLocation);
            GetAvailableMoves();
        }

        public void MoveCharacter(Vector3 newLocation)
        {
            Character.Location = newLocation;
            GetAvailableMoves();
        }

        public void GetAvailableMoves()
        {
            List<Vector3> availableMoves = new List<Vector3>();

            // Check all around the current character location for possible moves
            Vector3 NorthLocation = new Vector3(Character.Location.X, Character.Location.Y + 1, 0);
            Vector3 EastLocation = new Vector3(Character.Location.X + 1, Character.Location.Y, 0);
            Vector3 SouthLocation = new Vector3(Character.Location.X, Character.Location.Y - 1, 0);
            Vector3 WestLocation = new Vector3(Character.Location.X - 1, Character.Location.Y, 0);
            if (CheckLocationForPossibleMove(NorthLocation))
            {
                availableMoves.Add(NorthLocation);
                Character.NorthMoveAvailable = true;
            }
            if (CheckLocationForPossibleMove(EastLocation))
            {
                availableMoves.Add(EastLocation);
                Character.EastMoveAvailable = true;
            }
            if (CheckLocationForPossibleMove(SouthLocation))
            {
                availableMoves.Add(SouthLocation);
                Character.SouthMoveAvailable = true;
            }
            if (CheckLocationForPossibleMove(WestLocation))
            {
                availableMoves.Add(WestLocation);
                Character.WestMoveAvailable = true;
            }

            // Set the available moves for the character
            Character.AvailableMoves = availableMoves;
        }

        private bool CheckLocationForPossibleMove(Vector3 location)
        {
            int x = (int)location.X;
            int y = (int)location.Y;
            if (x < 0 || x >= Map.GetLength(0) || y < 0 || y >= Map.GetLength(1))
            {
                return false;
            }
            else
            {
                if (Map[(int)location.X, (int)location.Y] == "")
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

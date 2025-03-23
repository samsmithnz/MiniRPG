using MiniRPG.Logic.Map;
using System.Collections.Generic;
using System.Numerics;
using static MiniRPG.Logic.Map.CharacterAction;

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
            GetCharacterAvailableMoves();
        }

        public void MoveCharacter(Vector3 newLocation)
        {
            // if it's a door, open the door instead of moving
            if (Level.Map[(int)newLocation.X, (int)newLocation.Z] == MapTileType.MapTileType_DoorClosed)
            {
                Level.Map[(int)newLocation.X, (int)newLocation.Z] = MapTileType.MapTileType_DoorOpen; //Open door
            }
            else if (Level.Map[(int)newLocation.X, (int)newLocation.Z] == MapTileType.MapTileType_SwitchClosed)
            {
                Level.Map[(int)newLocation.X, (int)newLocation.Z] = MapTileType.MapTileType_SwitchOpen; //toggle the switch
            }
            else if (Level.Map[(int)newLocation.X, (int)newLocation.Z] == MapTileType.MapTileType_SwitchOpen)
            {
                Level.Map[(int)newLocation.X, (int)newLocation.Z] = MapTileType.MapTileType_SwitchClosed; //toggle the switch
            }
            else
            {
                Character.Location = newLocation;
            }
            GetCharacterAvailableMoves();
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

        public void GetCharacterAvailableMoves()
        {
            bool levelIsComplete = LevelIsComplete();

            if (!levelIsComplete)
            {
                // Check all around the current character location for possible moves
                Vector3 NorthLocation = new Vector3(Character.Location.X, 0, Character.Location.Z + 1);
                Vector3 EastLocation = new Vector3(Character.Location.X + 1, 0, Character.Location.Z);
                Vector3 SouthLocation = new Vector3(Character.Location.X, 0, Character.Location.Z - 1);
                Vector3 WestLocation = new Vector3(Character.Location.X - 1, 0, Character.Location.Z);
                Character.NorthMove = CheckLocationForPossibleMove(NorthLocation, DirectionEnum.North);
                Character.EastMove = CheckLocationForPossibleMove(EastLocation, DirectionEnum.East);
                Character.SouthMove = CheckLocationForPossibleMove(SouthLocation, DirectionEnum.South);
                Character.WestMove = CheckLocationForPossibleMove(WestLocation, DirectionEnum.West);
            }
            else
            {
                Character.NorthMove = null;
                Character.EastMove = null;
                Character.SouthMove = null;
                Character.WestMove = null;
            }
        }

        private CharacterAction CheckLocationForPossibleMove(Vector3 location, DirectionEnum direction)
        {
            int x = (int)location.X;
            int z = (int)location.Z;
            if (x < 0 || x >= Level.Map.GetLength(0) || z < 0 || z >= Level.Map.GetLength(1))
            {
                return null;
            }
            else
            {
                if (Level.Map[(int)location.X, (int)location.Z] == MapTileType.MapTileType_DoorOpen)
                {
                    // it's an open door, that will be closed
                    return new CharacterAction(false, location, true, "Close door", direction);
                }
                else if (Level.Map[(int)location.X, (int)location.Z] == MapTileType.MapTileType_DoorClosed)
                {
                    // it's an open door, that will be opened
                    return new CharacterAction(false, location, true, "Open door", direction);
                }
                else if (Level.Map[(int)location.X, (int)location.Z] == MapTileType.MapTileType_SwitchOpen)
                {
                    // it's an open switch, that will be closed
                    return new CharacterAction(false, location, true, "Close switch", direction);
                }
                else if (Level.Map[(int)location.X, (int)location.Z] == MapTileType.MapTileType_SwitchClosed)
                {
                    // it's a closed switch, that will be opened
                    return new CharacterAction(false, location, true, "Open switch", direction);
                }
                else if (Level.Map[(int)location.X, (int)location.Z] == MapTileType.MapTileType_EmptyTile)
                {
                    return new CharacterAction(true, location, false, direction.ToString(), direction);
                }
                else
                {
                    return null;
                }
            }
        }

    }
}

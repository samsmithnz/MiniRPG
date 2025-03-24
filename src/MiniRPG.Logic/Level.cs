using MiniRPG.Logic.Map;
using System.Numerics;

namespace MiniRPG.Logic
{
    public class Level
    {
        public int LevelNumber { get; set; }
        public Vector3 StartingLocation { get; set; }
        public Vector3 EndingLocation { get; set; }
        public string[,] Map { get; set; }
        public Vector3[,] Logic { get; set; }

        public Level(int levelNumber)
        {
            LevelNumber = levelNumber;
            switch (levelNumber)
            {
                case 1:
                    Level1();
                    break;
                case 2:
                    Level2();
                    break;
                case 3:
                    Level3();
                    break;
                case 4:
                    Level4();
                    break;
                case 5:
                    Level5();
                    break;
                default:
                    // Handle other levels
                    break;
            }
        }

        private void Level1()
        {
            int xMax = 5;
            int zMax = 5;
            string[,] map = MapCore.InitializeMap(xMax, zMax);
            Vector3 startingLocation = new Vector3(2, 0, 0);
            Vector3 endingLocation = new Vector3(2, 0, 4);

            //Create the outside walls
            for (int x = 0; x <= xMax - 1; x++)
            {
                for (int z = 0; z <= zMax - 1; z++)
                {
                    if (x == 0 || z == 0 || x == xMax - 1 || z == zMax - 1)
                    {
                        map[x, z] = MapTileType.MapTileType_WallOuter; //Outer wall
                    }
                }
            }

            //Clear the starting and ending locations
            map[(int)startingLocation.X, (int)startingLocation.Z] = MapTileType.MapTileType_EmptyTile;
            map[(int)endingLocation.X, (int)endingLocation.Z] = MapTileType.MapTileType_EmptyTile;

            //Set the global values for this level
            Map = map;
            StartingLocation = startingLocation;
            EndingLocation = endingLocation;
        }

        private void Level2()
        {
            int xMax = 9;
            int zMax = 9;
            string[,] map = MapCore.InitializeMap(xMax, zMax);
            Vector3 startingLocation = new Vector3(4, 0, 0);
            Vector3 endingLocation = new Vector3(4, 0, 8);

            //Create the outside walls
            for (int x = 0; x <= xMax - 1; x++)
            {
                for (int z = 0; z <= zMax - 1; z++)
                {
                    if (x == 0 || z == 0 || x == xMax - 1 || z == zMax - 1)
                    {
                        map[x, z] = MapTileType.MapTileType_WallOuter;
                    }
                }
            }

            //Create an inner wall with a door in the middle
            map[1, 4] = MapTileType.MapTileType_WallInner;
            map[2, 4] = MapTileType.MapTileType_WallInner;
            map[3, 4] = MapTileType.MapTileType_WallInner;
            map[4, 4] = MapTileType.MapTileType_DoorClosed; //closed inner door 
            map[5, 4] = MapTileType.MapTileType_WallInner;
            map[6, 4] = MapTileType.MapTileType_WallInner;
            map[7, 4] = MapTileType.MapTileType_WallInner;

            //Clear the starting and ending locations
            map[(int)startingLocation.X, (int)startingLocation.Z] = MapTileType.MapTileType_EmptyTile;
            map[(int)endingLocation.X, (int)endingLocation.Z] = MapTileType.MapTileType_EmptyTile;

            //Set the global values for this level
            Map = map;
            StartingLocation = startingLocation;
            EndingLocation = endingLocation;
        }

        private void Level3()
        {
            int xMax = 9;
            int zMax = 9;
            string[,] map = MapCore.InitializeMap(xMax, zMax);
            Vector3[,] logic = new Vector3[xMax, zMax];
            Vector3 startingLocation = new Vector3(4, 0, 0);
            Vector3 endingLocation = new Vector3(4, 0, 8);

            //Create the outside walls
            for (int x = 0; x <= xMax - 1; x++)
            {
                for (int z = 0; z <= zMax - 1; z++)
                {
                    if (x == 0 || z == 0 || x == xMax - 1 || z == zMax - 1)
                    {
                        map[x, z] = MapTileType.MapTileType_WallOuter;
                    }
                }
            }

            //Create an inner wall with a door in the middle
            map[1, 4] = MapTileType.MapTileType_WallInner;
            map[2, 4] = MapTileType.MapTileType_WallInner;
            map[3, 4] = MapTileType.MapTileType_WallInner;
            map[4, 4] = MapTileType.MapTileType_DoorLocked; //Locked door
            map[5, 4] = MapTileType.MapTileType_WallInner;
            map[6, 4] = MapTileType.MapTileType_WallInner;
            map[7, 4] = MapTileType.MapTileType_WallInner;
            map[5, 3] = MapTileType.MapTileType_SwitchClosed; //Switch in off position (on position is "S")

            logic[5, 3] = new Vector3(4, 0, 4);

            //Clear the starting and ending locations
            map[(int)startingLocation.X, (int)startingLocation.Z] = MapTileType.MapTileType_EmptyTile;
            map[(int)endingLocation.X, (int)endingLocation.Z] = MapTileType.MapTileType_EmptyTile;

            //Set the global values for this level
            Map = map;
            Logic = logic;
            StartingLocation = startingLocation;
            EndingLocation = endingLocation;
        }

        private void Level4()
        {

            int xMax = 9;
            int zMax = 13;
            string[,] map = MapCore.InitializeMap(xMax, zMax);
            Vector3[,] logic = new Vector3[xMax, zMax];
            Vector3 startingLocation = new Vector3(4, 0, 0);
            Vector3 endingLocation = new Vector3(4, 0, 12);

            //Create the outside walls
            for (int x = 0; x <= xMax - 1; x++)
            {
                for (int z = 0; z <= zMax - 1; z++)
                {
                    if (x == 0 || z == 0 || x == xMax - 1 || z == zMax - 1)
                    {
                        map[x, z] = MapTileType.MapTileType_WallOuter;
                    }
                }
            }

            //Create an inner wall with a door in the middle
            map[1, 3] = MapTileType.MapTileType_WallInner;
            map[2, 3] = MapTileType.MapTileType_WallInner;
            map[3, 3] = MapTileType.MapTileType_WallInner;
            map[4, 3] = MapTileType.MapTileType_DoorLocked; //Locked door
            map[5, 3] = MapTileType.MapTileType_WallInner;
            map[6, 3] = MapTileType.MapTileType_WallInner;
            map[7, 3] = MapTileType.MapTileType_WallInner;
            map[5, 2] = MapTileType.MapTileType_SwitchClosed; //Switch in off position (on position is "S")

            //Create an inner wall with a door in the middle
            map[1, 6] = MapTileType.MapTileType_WallInner;
            map[2, 6] = MapTileType.MapTileType_WallInner;
            map[3, 6] = MapTileType.MapTileType_WallInner;
            map[4, 6] = MapTileType.MapTileType_DoorLocked; //Locked door
            map[5, 6] = MapTileType.MapTileType_WallInner;
            map[6, 6] = MapTileType.MapTileType_WallInner;
            map[7, 6] = MapTileType.MapTileType_WallInner;
            map[5, 5] = MapTileType.MapTileType_SwitchClosed; //Switch in off position (on position is "S")

            //Create an inner wall with a door in the middle
            map[1, 9] = MapTileType.MapTileType_WallInner;
            map[2, 9] = MapTileType.MapTileType_WallInner;
            map[3, 9] = MapTileType.MapTileType_WallInner;
            map[4, 9] = MapTileType.MapTileType_DoorLocked; //Locked door
            map[5, 9] = MapTileType.MapTileType_WallInner;
            map[6, 9] = MapTileType.MapTileType_WallInner;
            map[7, 9] = MapTileType.MapTileType_WallInner;
            map[5, 8] = MapTileType.MapTileType_SwitchClosed; //Switch in off position (on position is "S")

            logic[5, 2] = new Vector3(4, 0, 3);
            logic[5, 5] = new Vector3(4, 0, 6);
            logic[5, 8] = new Vector3(4, 0, 9);

            //Clear the starting and ending locations
            map[(int)startingLocation.X, (int)startingLocation.Z] = MapTileType.MapTileType_EmptyTile;
            map[(int)endingLocation.X, (int)endingLocation.Z] = MapTileType.MapTileType_EmptyTile;

            //Set the global values for this level
            Map = map;
            Logic = logic;
            StartingLocation = startingLocation;
            EndingLocation = endingLocation;
        }

        private void Level5()
        {
            int xMax = 9;
            int zMax = 9;
            string[,] map = MapCore.InitializeMap(xMax, zMax);
            Vector3[,] logic = new Vector3[xMax, zMax];
            Vector3 startingLocation = new Vector3(4, 0, 0);
            Vector3 endingLocation = new Vector3(4, 0, 8);

            //Create the outside walls
            for (int x = 0; x <= xMax - 1; x++)
            {
                for (int z = 0; z <= zMax - 1; z++)
                {
                    if (x == 0 || z == 0 || x == xMax - 1 || z == zMax - 1)
                    {
                        map[x, z] = MapTileType.MapTileType_WallOuter;
                    }
                }
            }

            //Create an inner wall with a door in the middle
            map[1, 4] = MapTileType.MapTileType_WallInner;
            map[2, 4] = MapTileType.MapTileType_WallInner;
            map[3, 4] = MapTileType.MapTileType_WallInner;
            map[4, 4] = MapTileType.MapTileType_DoorLocked; //Locked door
            map[5, 4] = MapTileType.MapTileType_WallInner;
            map[6, 4] = MapTileType.MapTileType_WallInner;
            map[7, 4] = MapTileType.MapTileType_WallInner;
            map[5, 3] = MapTileType.MapTileType_SwitchClosed; //Switch in off position (on position is "S")
            logic[5, 3] = new Vector3(4, 0, 4);

            //Create an external door and switch
            map[0, 6] = MapTileType.MapTileType_DoorLocked; //Locked external door
            map[3, 3] = MapTileType.MapTileType_SwitchClosed; //Switch in off position (on position is "S")
            logic[3, 3] = new Vector3(0, 0, 6);

            //Add poisionise gas to top section 
            for (int x = 1; x < xMax-1; x++)
            {
                for (int z = 5; z < zMax-1; z++)
                {
                    map[x, z] = MapTileType.MapTileType_PoisonGas;
                }
            }

            //Clear the starting and ending locations
            map[(int)startingLocation.X, (int)startingLocation.Z] = MapTileType.MapTileType_EmptyTile;
            map[(int)endingLocation.X, (int)endingLocation.Z] = MapTileType.MapTileType_EmptyTile;

            //Set the global values for this level
            Map = map;
            Logic = logic;
            StartingLocation = startingLocation;
            EndingLocation = endingLocation;
        }

        public string Level1Board = @"
W W . W W 
W . . . W 
W . . . W 
W . . . W 
W W . W W 
";
        public string Level2Board = @"
W W W W . W W W W 
W . . . . . . . W 
W . . . . . . . W 
W . . . . . . . W 
W w w w d w w w W 
W . . . . . . . W 
W . . . . . . . W 
W . . . . . . . W 
W W W W . W W W W 
";
        public string Level3Board = @"
W W W W . W W W W 
W . . . . . . . W 
W . . . . . . . W 
W . . . . . . . W 
W w w w a w w w W 
W . . . . s . . W 
W . . . . . . . W 
W . . . . . . . W 
W W W W . W W W W 
";
        public string Level4Board = @"
W W W W . W W W W 
W . . . . . . . W 
W . . . . . . . W 
W w w w a w w w W 
W . . . . s . . W 
W . . . . . . . W 
W w w w a w w w W 
W . . . . s . . W 
W . . . . . . . W 
W w w w a w w w W 
W . . . . s . . W 
W . . . . . . . W 
W W W W . W W W W 
";

        public string Level5Board = @"
W W W W . W W W W 
W g g g g g g g W 
a g g g g g g g W 
W g g g g g g g W 
W w w w a w w w W 
W . . s . s . . W 
W . . . . . . . W 
W . . . . . . . W 
W W W W . W W W W 
";

        public string[,] ProcessLevelBoard(string levelBoard)
        {
            // Split the board string into lines
            string[] lines = levelBoard.Trim().Split('\n');
            int rows = lines.Length;
            int cols = lines[0].Trim().Length;

            // Initialize the 2D array
            string[,] boardArray = new string[rows, cols];

            // Fill the 2D array with characters from the board string
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    boardArray[i, j] = lines[i][j].ToString();
                }
            }

            return boardArray;
        }

    }
}

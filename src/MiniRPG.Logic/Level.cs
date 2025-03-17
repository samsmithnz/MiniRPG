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
                        map[x, z] = "W"; //Outer wall
                    }

                }
            }
            //Clear the starting and ending locations
            map[(int)startingLocation.X, (int)startingLocation.Z] = "";
            map[(int)endingLocation.X, (int)endingLocation.Z] = "";

            //Set the global values for this level
            Map = map;
            StartingLocation = startingLocation;
            EndingLocation = endingLocation;
        }

        private void Level2() {
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
                        map[x, z] = "W";
                    }

                }
            }

            //Create an inner wall with a door in the middle
            map[1, 4] = "w";
            map[2, 4] = "w";
            map[3, 4] = "w";
            map[4, 4] = "d"; //closed inner door (open inner door is "D")
            map[5, 4] = "w";
            map[6, 4] = "w";
            map[7, 4] = "w";

            //Clear the starting and ending locations
            map[(int)startingLocation.X, (int)startingLocation.Z] = "";
            map[(int)endingLocation.X, (int)endingLocation.Z] = "";

            //Set the global values for this level
            Map = map;
            StartingLocation = startingLocation;
            EndingLocation = endingLocation;
        }

        private void Level3() {
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
                        map[x, z] = "W";
                    }

                }
            }

            //Create an inner wall with a door in the middle
            map[1, 4] = "W";
            map[2, 4] = "W";
            map[3, 4] = "W";
            map[4, 4] = "a"; //CLosed Airlock door
            map[5, 4] = "W";
            map[6, 4] = "W";
            map[7, 4] = "W";
            map[5, 3] = "s"; //Switch in off position (on position is "S")

            //Clear the starting and ending locations
            map[(int)startingLocation.X, (int)startingLocation.Z] = "";
            map[(int)endingLocation.X, (int)endingLocation.Z] = "";

            //Set the global values for this level
            Map = map;
            StartingLocation = startingLocation;
            EndingLocation = endingLocation;
        }

        public string Level1Board = @"
WW.WW
W...W
W...W
W...W
WW.WW
";
        public string Level2Board = @"
WWWW.WWWW
W.......W
W.......W
W.......W
WwwwdwwwW
W.......W
W.......W
W.......W
WWWW.WWWW
";
        public string Level3Board = @"
WWWW.WWWW
W.......W
W.......W
W.......W
WWWWAWWWW
W....s..W
W.......W
W.......W
WWWW.WWWW
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

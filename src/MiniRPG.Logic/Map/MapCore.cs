using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace MiniRPG.Logic.Map
{
    public class MapCore
    {
        /// <summary>
        /// Initialize a x by y map array
        /// </summary>
        /// <param name="xMax">x size</param>
        /// <param name="zMax">z size</param>
        /// <param name="initialString">The initial string to initialize the map with - usually ""</param>
        /// <returns>The populated map/array</returns>
        public static string[,] InitializeMap(int xMax, int zMax, string initialString = "")
        {
            string[,] map = new string[xMax, zMax];

            //Initialize the map
            for (int z = 0; z < zMax; z++)
            {
                for (int x = 0; x < xMax; x++)
                {
                    map[x, z] = initialString;
                }
            }

            return map;
        }

        public static string GetMapString(string[,] map, bool stripOutBlanks = false)
        {
            int xMax = map.GetLength(0);
            int zMax = map.GetLength(1);
            StringBuilder sb = new StringBuilder();
            sb.Append(Environment.NewLine);
            for (int z = zMax - 1; z >= 0; z--)
            {
                StringBuilder sbLine = new StringBuilder();
                for (int x = 0; x < xMax; x++)
                {
                    if (map[x, z] != "")
                    {
                        sbLine.Append(map[x, z] + " ");
                    }
                    else
                    {
                        sbLine.Append(". ");
                    }
                }
                sbLine.Append(Environment.NewLine);
                //If there is nothing on the map line, don't display it.
                //This optimizes the ASCII maps to remove white space
                if (stripOutBlanks)
                {
                    int dotCount = sbLine.ToString().Split('.').Count() - 1;
                    if (dotCount < xMax)
                    {
                        sb.Append(sbLine.ToString());
                    }
                }
                else
                {
                    sb.Append(sbLine.ToString());
                }
            }
            return sb.ToString();
        }

        public static string[,] AddTileTypesToMap(string[,] map, Dictionary<Vector3, string> tileTypeList)
        {
            //loop through the tileTypeList and add the tiles to the map
            foreach (KeyValuePair<Vector3, string> item in tileTypeList)
            {
                //Check that the square is empty - we don't want to overwrite something that exists and only put a tile on an unused tile
                if (map[(int)item.Key.X, (int)item.Key.Z] == MapTileType.MapTileType_EmptyTile)
                {
                    map[(int)item.Key.X, (int)item.Key.Z] = item.Value;
                }
            }
            return map;
        }
    }
}

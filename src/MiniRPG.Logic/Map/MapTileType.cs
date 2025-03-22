using System;
using System.Collections.Generic;
using System.Text;

namespace MiniRPG.Logic.Map
{
    public static class MapTileType
    {
        public const string MapTileType_EmptyTile = "";
        public const string MapTileType_DoorLocked = "a";
        public const string MapTileType_DoorClosed = "d";
        public const string MapTileType_DoorOpen = "D";
        public const string MapTileType_SwitchClosed = "s";
        public const string MapTileType_SwitchOpen = "S";
        public const string MapTileType_WallInner = "w";
        public const string MapTileType_WallOuter = "W";
    }
}

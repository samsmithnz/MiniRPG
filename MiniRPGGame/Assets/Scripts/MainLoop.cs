using MiniRPG.Logic;
using MiniRPG.Logic.Map;
using System;
using UnityEngine;
using static UnityEditor.FilePathAttribute;

namespace Assets.Scripts
{
    public class MainLoop : MonoBehaviour
    {
        private Game _game;
        private GameObject _buttonNorth;
        private GameObject _buttonEast;
        private GameObject _buttonSouth;
        private GameObject _buttonWest;

        void Start()
        {
            int xMax = 7;
            int yMax = 7;
            string[,] map = MapCore.InitializeMap(xMax, yMax);
            Vector3 startingLocation = new Vector3(3, 0, 0);

            Level.SetupLevel(gameObject, map, true, true, startingLocation);

            _buttonNorth = GameObject.Find("ButtonNorth");
            _buttonEast = GameObject.Find("ButtonEast");
            _buttonSouth = GameObject.Find("ButtonSouth");
            _buttonWest = GameObject.Find("ButtonWest");

            _game = new(map, Utility.ConvertToNumericsV3(startingLocation));
            MoveCharacter(startingLocation);
        }

        private void MoveCharacter(Vector3 location)
        {
            GameObject character = GameObject.Find("character");
            character.transform.position = location;

            Debug.Log("New position: " + _game.GetAvailableMoves());
            if (_buttonNorth != null)
            {
                if (_game.Character.NorthMoveAvailable)
                {
                    _buttonNorth.SetActive(true);
                }
                else
                {
                    _buttonNorth.SetActive(false);
                }
            }
            if (_buttonEast != null)
            {
                if (_game.Character.EastMoveAvailable)
                {
                    _buttonEast.SetActive(true);
                }
                else
                {
                    _buttonEast.SetActive(false);
                }
            }
            if (_buttonSouth != null)
            {
                if (_game.Character.SouthMoveAvailable)
                {
                    _buttonSouth.SetActive(true);
                }
                else
                {
                    _buttonSouth.SetActive(false);
                }
            }
            if (_buttonWest != null)
            {
                if (_game.Character.WestMoveAvailable)
                {
                    _buttonWest.SetActive(true);
                }
                else
                {
                    _buttonWest.SetActive(false);
                }
            }
        }

        public void MoveNorth()
        {
            Debug.Log("Move North");
            Vector3 newLocation = new Vector3(_game.Character.Location.X, _game.Character.Location.Y, _game.Character.Location.Z + 1);
            _game.Character.Location = Utility.ConvertToNumericsV3(newLocation);
            MoveCharacter(newLocation);
        }

        public void MoveEast()
        {
            Debug.Log("Move East");
            Vector3 newLocation = new Vector3(_game.Character.Location.X + 1, _game.Character.Location.Y, _game.Character.Location.Z + 1);
            _game.Character.Location = Utility.ConvertToNumericsV3(newLocation);
            MoveCharacter(newLocation);
        }

        public void MoveSouth()
        {
            Debug.Log("Move South");
            Vector3 newLocation = new Vector3(_game.Character.Location.X, _game.Character.Location.Y, _game.Character.Location.Z - 1);
            _game.Character.Location = Utility.ConvertToNumericsV3(newLocation);
            MoveCharacter(newLocation);
        }

        public void MoveWest()
        {
            Debug.Log("Move West");
            Vector3 newLocation = new Vector3(_game.Character.Location.X - 1, _game.Character.Location.Y, _game.Character.Location.Z);
            _game.Character.Location = Utility.ConvertToNumericsV3(newLocation);
            MoveCharacter(newLocation);
        }
    }
}

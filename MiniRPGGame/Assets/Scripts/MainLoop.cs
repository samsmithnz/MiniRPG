﻿using MiniRPG.Logic;
using MiniRPG.Logic.Map;
using TMPro;
using UnityEngine;

namespace Assets.Scripts
{
    public class MainLoop : MonoBehaviour
    {
        private Game _game;
        private GameObject _buttonNorth;
        private GameObject _buttonEast;
        private GameObject _buttonSouth;
        private GameObject _buttonWest;
        private int _levelNumber = 1;

        void Start()
        {
            _buttonNorth = GameObject.Find("ButtonNorth");
            _buttonEast = GameObject.Find("ButtonEast");
            _buttonSouth = GameObject.Find("ButtonSouth");
            _buttonWest = GameObject.Find("ButtonWest");

            _levelNumber = 3;
            SetupGame(_levelNumber);
        }

        private void SetupGame(int levelNumber)
        {
            _game = new(levelNumber);
            Level.SetupLevel(gameObject,
                _levelNumber,
                _game.Level.Map,
                true,
                true,
                Utility.ConvertToUnity3DV3(_game.Level.StartingLocation),
                Utility.ConvertToUnity3DV3(_game.Level.EndingLocation));
            if (_game.Level.Map != null)
            {
                MoveCharacter(Utility.ConvertToUnity3DV3(_game.Level.StartingLocation));
            }
        }

        private void MoveCharacter(Vector3 location)
        {
            GameObject character = GameObject.Find("Character");
            character.transform.position = location;

            if (_game.LevelIsComplete())
            {
                _levelNumber++;
                SetupGame(_levelNumber);
            }
            else
            {

                //Debug.Log("New position: " + _game.GetAvailableMoves());
                if (_buttonNorth != null)
                {
                    if (_game.Character.NorthMove != null)
                    {
                        _buttonNorth.SetActive(true);
                        //Update the button text
                        GameObject buttonNorthText = _buttonNorth.transform.GetChild(0).gameObject;
                        if (buttonNorthText != null)
                        {
                            buttonNorthText.GetComponent<TextMeshPro>().text = _game.Character.NorthMove.ActionName;
                        }
                    }
                    else
                    {
                        _buttonNorth.SetActive(false);
                    }
                }
                if (_buttonEast != null)
                {
                    if (_game.Character.EastMove != null)
                    {
                        _buttonEast.SetActive(true);
                        //Update the button text
                        GameObject buttonEastText = _buttonEast.transform.GetChild(0).gameObject;
                        if (buttonEastText != null)
                        {
                            buttonEastText.GetComponent<TextMeshPro>().text = _game.Character.EastMove.ActionName;
                        }
                    }
                    else
                    {
                        _buttonEast.SetActive(false);
                    }
                }
                if (_buttonSouth != null)
                {
                    if (_game.Character.SouthMove != null)
                    {
                        _buttonSouth.SetActive(true);
                        //Update the button text
                        GameObject buttonSouthText = _buttonSouth.transform.GetChild(0).gameObject;
                        if (buttonSouthText != null)
                        {
                            buttonSouthText.GetComponent<TextMeshPro>().text = _game.Character.SouthMove.ActionName;
                        }
                    }
                    else
                    {
                        _buttonSouth.SetActive(false);
                    }
                }
                if (_buttonWest != null)
                {
                    if (_game.Character.WestMove != null)
                    {
                        _buttonWest.SetActive(true);
                        //Update the button text
                        GameObject buttonWestText = _buttonWest.transform.GetChild(0).gameObject;
                        if (buttonWestText != null)
                        {
                            buttonWestText.GetComponent<TextMeshPro>().text = _game.Character.WestMove.ActionName;
                        }
                    }
                    else
                    {
                        _buttonWest.SetActive(false);
                    }
                }
            }
        }

        public void MoveNorth()
        {
            Debug.Log("Move North");
            Vector3 newLocation = new(_game.Character.Location.X, _game.Character.Location.Y, _game.Character.Location.Z + 1);
            _game.MoveCharacter(Utility.ConvertToNumericsV3(newLocation));
            if (_game.Character.Location != Utility.ConvertToNumericsV3(GameObject.Find("Character").transform.position))
            {
                MoveCharacter(newLocation);
            }
            else if (_game.Level.Map[(int)newLocation.x, (int)newLocation.z] == "D")
            {
                //Open the door
                GameObject doorPrefab = GameObject.Find("InternalSkinnyDoor_x" + newLocation.x + "_z" + newLocation.z);
                if (doorPrefab != null)
                {
                    GameObject door = doorPrefab.transform.Find("SM_Buildings_Door").gameObject;
                    if (door != null)
                    {
                        door.SetActive(false);
                    }
                }
            }
        }

        public void MoveEast()
        {
            Debug.Log("Move East");
            Vector3 newLocation = new(_game.Character.Location.X + 1, _game.Character.Location.Y, _game.Character.Location.Z);
            _game.Character.Location = Utility.ConvertToNumericsV3(newLocation);
            MoveCharacter(newLocation);
        }

        public void MoveSouth()
        {
            Debug.Log("Move South");
            Vector3 newLocation = new(_game.Character.Location.X, _game.Character.Location.Y, _game.Character.Location.Z - 1);
            _game.Character.Location = Utility.ConvertToNumericsV3(newLocation);
            MoveCharacter(newLocation);
        }

        public void MoveWest()
        {
            Debug.Log("Move West");
            Vector3 newLocation = new(_game.Character.Location.X - 1, _game.Character.Location.Y, _game.Character.Location.Z);
            _game.Character.Location = Utility.ConvertToNumericsV3(newLocation);
            MoveCharacter(newLocation);
        }

        //capture key presses to move north when w or arrow is pressed
        void Update()
        {
            // Capture key presses to move north when W or up arrow is pressed
            if (_buttonNorth.activeSelf && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)))
            {
                MoveNorth();
            }
            else if (_buttonEast.activeSelf && (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)))
            {
                MoveEast();
            }
            else if (_buttonSouth.activeSelf && (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)))
            {
                MoveSouth();
            }
            else if (_buttonWest.activeSelf && (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)))
            {
                MoveWest();
            }
        }

    }
}

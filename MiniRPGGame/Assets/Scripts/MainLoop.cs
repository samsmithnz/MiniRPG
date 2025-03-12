using MiniRPG.Logic;
using MiniRPG.Logic.Map;
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

            _levelNumber = 1;
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
            MoveCharacter(Utility.ConvertToUnity3DV3(_game.Level.StartingLocation));
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
        }

        public void MoveNorth()
        {
            Debug.Log("Move North");
            Vector3 newLocation = new(_game.Character.Location.X, _game.Character.Location.Y, _game.Character.Location.Z + 1);
            _game.Character.Location = Utility.ConvertToNumericsV3(newLocation);
            MoveCharacter(newLocation);
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

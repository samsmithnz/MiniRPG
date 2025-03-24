using MiniRPG.Logic;
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
        private int _levelNumber;

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
                        SetButtonText(_buttonNorth, _game.Character.NorthMove.Name);
                        GameObject buttonNorthText = _buttonNorth.transform.GetChild(0).gameObject;
                        if (buttonNorthText != null)
                        {
                            buttonNorthText.GetComponent<TextMeshProUGUI>().text = _game.Character.NorthMove.Name;
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
                            buttonEastText.GetComponent<TextMeshProUGUI>().text = _game.Character.EastMove.Name;
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
                            buttonSouthText.GetComponent<TextMeshProUGUI>().text = _game.Character.SouthMove.Name;
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
                            buttonWestText.GetComponent<TextMeshProUGUI>().text = _game.Character.WestMove.Name;
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
            Debug.Log(GetButtonText(_buttonNorth) + " starting at " + _game.Character.Location.ToString());
            Vector3 newLocation = new(_game.Character.Location.X, _game.Character.Location.Y, _game.Character.Location.Z + 1);
            if (_game.Character.NorthMove != null)
            {
                if (_game.Character.NorthMove.IsMove)
                {
                    _game.MoveCharacter(Utility.ConvertToNumericsV3(newLocation));
                    MoveCharacter(newLocation);
                }
                else if (_game.Character.NorthMove.IsAction)
                {
                    PerformActions(newLocation);
                }
            }
            Debug.Log(GetButtonText(_buttonNorth) + " ending at " + _game.Character.Location.ToString());
        }

        public void MoveEast()
        {
            Debug.Log(GetButtonText(_buttonEast) + " starting at " + _game.Character.Location.ToString());
            Vector3 newLocation = new(_game.Character.Location.X + 1, _game.Character.Location.Y, _game.Character.Location.Z);
            if (_game.Character.EastMove != null)
            {
                if (_game.Character.EastMove.IsMove)
                {
                    _game.MoveCharacter(Utility.ConvertToNumericsV3(newLocation));
                    MoveCharacter(newLocation);
                }
                else if (_game.Character.EastMove.IsAction)
                {
                    PerformActions(newLocation);
                }
            }

            //_game.Character.Location = Utility.ConvertToNumericsV3(newLocation);
            //MoveCharacter(newLocation);
            Debug.Log(GetButtonText(_buttonEast) + " ending at " + _game.Character.Location.ToString());
        }

        public void MoveSouth()
        {
            Debug.Log(GetButtonText(_buttonSouth) + " starting at " + _game.Character.Location.ToString());
            Vector3 newLocation = new(_game.Character.Location.X, _game.Character.Location.Y, _game.Character.Location.Z - 1);
            if (_game.Character.SouthMove != null)
            {
                if (_game.Character.SouthMove.IsMove)
                {
                    _game.MoveCharacter(Utility.ConvertToNumericsV3(newLocation));
                    MoveCharacter(newLocation);
                }
                else if (_game.Character.SouthMove.IsAction)
                {
                    PerformActions(newLocation);
                }
            }

            //_game.Character.Location = Utility.ConvertToNumericsV3(newLocation);
            //MoveCharacter(newLocation);
            Debug.Log(GetButtonText(_buttonSouth) + " ending at " + _game.Character.Location.ToString());
        }

        public void MoveWest()
        {
            Debug.Log(GetButtonText(_buttonWest) + " starting at " + _game.Character.Location.ToString());
            Vector3 newLocation = new(_game.Character.Location.X - 1, _game.Character.Location.Y, _game.Character.Location.Z);
            if (_game.Character.WestMove != null)
            {
                if (_game.Character.WestMove.IsMove)
                {
                    _game.MoveCharacter(Utility.ConvertToNumericsV3(newLocation));
                    MoveCharacter(newLocation);
                }
                else if (_game.Character.WestMove.IsAction)
                {
                    PerformActions(newLocation);
                }
            }

            Debug.Log(GetButtonText(_buttonWest) + " ending at " + _game.Character.Location.ToString());
        }

        private void PerformActions(Vector3 location)
        {
            if (_game.Level.Map[(int)location.x, (int)location.z] == MapTileType.MapTileType_DoorClosed)
            {
                //Open the door
                GameObject doorPrefab = GameObject.Find("InternalSkinnyDoor_x" + location.x + "_z" + location.z);
                if (doorPrefab != null)
                {
                    GameObject door = doorPrefab.transform.Find("SM_Buildings_Door").gameObject;
                    if (door != null)
                    {
                        door.SetActive(false);
                    }
                }
                _game.MoveCharacter(Utility.ConvertToNumericsV3(location));
                MoveCharacter(new(_game.Character.Location.X, _game.Character.Location.Y, _game.Character.Location.Z));
            }
            else if (_game.Level.Map[(int)location.x, (int)location.z] == MapTileType.MapTileType_SwitchClosed)
            {
                //Open the switch
                GameObject switchPrefab = GameObject.Find("Switch_x" + location.x + "_z" + location.z);
                if (switchPrefab != null)
                {
                    GameObject switchLever = switchPrefab.transform.GetChild(0).GetChild(0).gameObject;
                    if (switchLever != null)
                    {
                        Debug.Log("Switch is turning on");
                        //set the level to on/open
                        switchLever.transform.rotation = Quaternion.Euler(-30, 0, 0);
                    }
                }
                //Open the door
                Vector3 doorLocation = Utility.ConvertToUnity3DV3(_game.Level.Logic[(int)location.x, (int)location.z]);
                if (doorLocation != Vector3.zero)
                {
                    GameObject doorPrefab = GameObject.Find("InternalSkinnyDoor_x" + doorLocation.x + "_z" + doorLocation.z);
                    if (doorPrefab != null)
                    {
                        GameObject door = doorPrefab.transform.Find("SM_Buildings_Door").gameObject;
                        if (door != null)
                        {
                            Debug.Log("Switch is unlocking and opening door");
                            door.SetActive(false);
                        }
                    }
                }
                _game.MoveCharacter(Utility.ConvertToNumericsV3(location));
                MoveCharacter(new(_game.Character.Location.X, _game.Character.Location.Y, _game.Character.Location.Z));
            }
        }

        private void SetButtonText(GameObject button, string buttonText)
        {
            GameObject buttonTextObject = button.transform.GetChild(0).gameObject;
            if (buttonText != null)
            {
                buttonTextObject.GetComponent<TextMeshProUGUI>().text = buttonText;
            }
        }

        private string GetButtonText(GameObject button)
        {
            GameObject buttonTextObject = button.transform.GetChild(0).gameObject;
            if (buttonTextObject != null)
            {
                return buttonTextObject.GetComponent<TextMeshProUGUI>().text;
            }
            return "";
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

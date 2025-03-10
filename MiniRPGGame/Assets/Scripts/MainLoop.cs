using MiniRPG.Logic;
using MiniRPG.Logic.Map;
using UnityEngine;

namespace Assets.Scripts
{
    public class MainLoop : MonoBehaviour
    {
        void Start()
        {         
            int xMax = 7;
            int yMax = 7;
            string[,] map = MapCore.InitializeMap(xMax, yMax);
            Vector3 startingLocation = new Vector3(3, 0, 0);

            Level.SetupLevel(gameObject, map, true, true, startingLocation);
       
            Game game = new(map, Utility.ConvertToNumericsV3(startingLocation));
            if (game.Character.NorthMoveAvailable)
            {
                GameObject.Find("ButtonNorth").SetActive(true);
            }
            else
            {
                GameObject.Find("ButtonNorth").SetActive(false);
            }
            if (game.Character.EastMoveAvailable)
            {
                GameObject.Find("ButtonEast").SetActive(true);
            }
            else
            {
                GameObject.Find("ButtonEast").SetActive(false);
            }
            if (game.Character.SouthMoveAvailable)
            {
                GameObject.Find("ButtonSouth").SetActive(true);
            }
            else
            {
                GameObject.Find("ButtonSouth").SetActive(false);
            }
            if (game.Character.WestMoveAvailable)
            {
                GameObject.Find("ButtonWest").SetActive(true);
            }
            else
            {
                GameObject.Find("ButtonWest").SetActive(false);
            }
        }

       public void MoveNorth()
        {
            Debug.Log("Move North");
        }

        public void MoveEast()
        {
            Debug.Log("Move East");
        }

        public void MoveSouth()
        {
            Debug.Log("Move South");
        }

        public void MoveWest()
        {
            Debug.Log("Move West");
        }
    }
}

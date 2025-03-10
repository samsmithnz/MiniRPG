using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor.Playables;
using UnityEngine;

namespace Assets.Scripts
{
    public class Level : MonoBehaviour
    {
        //public string[,] Map { get; set; }
        //public Character Character { get; set; }
        //public Vector3 CharacterStartingLocation { get; set; }
        //public Level(string[,] map, Character character, Vector3 characterStartingLocation)
        //{
        //    Map = map;
        //    Character = character;
        //    CharacterStartingLocation = characterStartingLocation;
        //}

        public static void SetupLevel(GameObject parentGameObject, string[,] map, bool showLinesOnFloor, bool showCoordsOnFloor, Vector3 startingLocation)
        {
            Font font = Resources.GetBuiltinResource(typeof(Font), "LegacyRuntime.ttf") as Font;
            int width = map.GetLength(0);
            //int height = map.GetLength(1);
            int breadth = map.GetLength(1);

            ////setup the map object and create the map
            //GameObject parentFloor = new GameObject
            //{
            //    name = "parentFloor"
            //};
            //parentFloor.transform.parent = parentGameObject.transform;

            //Draw the map on the screen
            for (int x = 0; x <= width - 1; x++)
            {
                for (int y = 0; y <= breadth - 1; y++)
                {
                    //Create map floor
                    GameObject newFloorObject = new GameObject();//.CreatePrimitive(PrimitiveType.Cube);
                    newFloorObject.transform.position = new Vector3(x, -0.5f, y);
                    newFloorObject.name = Utility.CreateName("floor_type_" + map[x, y], newFloorObject.transform.position);
                    newFloorObject.transform.parent = parentGameObject.transform;

                    if (showCoordsOnFloor == true)
                    {
                        GameObject newFloorCanvasObject = new GameObject
                        {
                            name = "Canvas"
                        };
                        newFloorCanvasObject.transform.parent = newFloorObject.transform;
                        Canvas floorCanvas = newFloorCanvasObject.AddComponent<Canvas>();
                        floorCanvas.transform.localPosition = Vector3.zero;
                        floorCanvas.renderMode = RenderMode.WorldSpace;
                        floorCanvas.worldCamera = Camera.main;

                        GameObject newFloorTextObject = new GameObject
                        {
                            name = "Text"
                        };
                        newFloorTextObject.transform.SetParent(newFloorCanvasObject.transform);
                        UnityEngine.UI.Text floorText = newFloorTextObject.transform.gameObject.AddComponent<UnityEngine.UI.Text>();
                        floorText.transform.localPosition = new Vector3(0f, 0.501f, 0f);
                        floorText.transform.localRotation = Quaternion.Euler(90f, 0f, 0f);
                        floorText.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
                        //floorText.transform.parent = floorCanvas.transform;
                        floorText.rectTransform.sizeDelta = new Vector2(100f, 100f);
                        floorText.color = Color.black;
                        floorText.alignment = TextAnchor.MiddleCenter;
                        floorText.fontSize = 24;
                        floorText.font = font;
                        floorText.text = "x" + x.ToString() + ",y" + y.ToString();
                    }

                    //GameObject newObject = GameObject.Instantiate(Resources.Load<GameObject>("PolygonStarter/Prefabs/SM_PolygonPrototype_Buildings_Block_1x1_01P"), Vector3.zero, Quaternion.identity) as GameObject;


                    //Create map objects, if exists
                    //if (map[x, y, z] != "")
                    //{
                    //    CreateCoverObject(new Vector3(x, y, z), map[x, y, z], newFloorObject.transform);
                    //}

                    if (showLinesOnFloor == true)
                    {
                        //Draw line renderers
                        if (x == 0 && y != breadth - 1)
                        {
                            LineRenderer xGuideLine = newFloorObject.AddComponent<LineRenderer>();
                            if (xGuideLine != null)
                            {
                                xGuideLine.material = new Material(Shader.Find("Sprites/Default"));
                                xGuideLine.widthMultiplier = 0.04f;
                                xGuideLine.startColor = Color.cyan;
                                xGuideLine.endColor = Color.cyan;
                                xGuideLine.SetPosition(0, new Vector3(-0.5f, 0.01f, y + 0.5f));
                                xGuideLine.SetPosition(1, new Vector3(width - 0.5f, 0.01f, y + 0.5f));
                            }
                        }
                        else if (y == breadth - 1 && x != 0)
                        {
                            LineRenderer yGuideLine = newFloorObject.AddComponent<LineRenderer>();
                            if (yGuideLine != null)
                            {
                                yGuideLine.material = new Material(Shader.Find("Sprites/Default"));
                                yGuideLine.widthMultiplier = 0.04f;
                                yGuideLine.startColor = Color.cyan;
                                yGuideLine.endColor = Color.cyan;
                                yGuideLine.SetPosition(0, new Vector3(x - 0.5f, 0.01f, -0.5f));
                                yGuideLine.SetPosition(1, new Vector3(x - 0.5f, 0.01f, breadth - 0.5f));
                            }
                        }
                    }

                } //end z for
            } //end x for

            //Create the character
            GameObject characterObject = GameObject.CreatePrimitive(PrimitiveType.Capsule);
            characterObject.transform.position = startingLocation;
            characterObject.name = "character";
            characterObject.transform.parent = parentGameObject.transform;
            //Add the blue material to the character
            Material blueMaterial = new Material(Shader.Find("Unlit/Color"));
            blueMaterial.SetColor("_Color", Color.blue);
            characterObject.GetComponent<Renderer>().material = blueMaterial;
        }
    }
}

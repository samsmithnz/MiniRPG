using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Analytics;
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

        public static void SetupLevel(GameObject parentGameObject,
            int levelNumber,
            string[,] map,
            bool showLinesOnFloor,
            bool showCoordsOnFloor,
            Vector3 startingLocation,
            Vector3 endingLocation)
        {
            if (map.Length == 0)
            {
                Debug.LogError("No map found - perhaps this is the end of the road? GAME OVER!!");
            }

            Font font = Resources.GetBuiltinResource(typeof(Font), "LegacyRuntime.ttf") as Font;
            int width = map.GetLength(0);
            //int height = map.GetLength(1);
            int breadth = map.GetLength(1);

            // start by deleting the preview map
            GameObject floorTypeToDelete = GameObject.Find("FloorType");
            if (floorTypeToDelete != null)
            {
                GameObject.Destroy(floorTypeToDelete);
            }
            GameObject outsideWallsToDelete = GameObject.Find(name: "OutsideWalls");
            if (outsideWallsToDelete != null)
            {
                GameObject.Destroy(outsideWallsToDelete);
            }
            GameObject startAndEndIndicatorsToDelete = GameObject.Find(name: "StartAndEndIndicators");
            if (startAndEndIndicatorsToDelete != null)
            {
                GameObject.Destroy(startAndEndIndicatorsToDelete);
            }
            GameObject characterToDelete = GameObject.Find(name: "Character");
            if (characterToDelete != null)
            {
                GameObject.Destroy(characterToDelete);
            }

            ////setup the map object and create the map
            //GameObject parentFloor = new GameObject
            //{
            //    name = "parentFloor"
            //};
            //parentFloor.transform.parent = parentGameObject.transform;

            GameObject textLevel = GameObject.Find("TextLevel");
            if (textLevel != null)
            {
                textLevel.GetComponent<TextMeshProUGUI>().text = "Level: " + levelNumber.ToString();
            }
            //Draw the map on the screen
            GameObject floorType = new()
            {
                name = "FloorType"
            };
            floorType.transform.parent = parentGameObject.transform;
            for (int x = 0; x <= width - 1; x++)
            {
                for (int z = 0; z <= breadth - 1; z++)
                {
                    //Create map floor
                    GameObject newFloorObject = new();//.CreatePrimitive(PrimitiveType.Cube);
                    newFloorObject.transform.position = new Vector3(x, -0.5f, z);
                    newFloorObject.name = Utility.CreateName("floor_type_" + map[x, z], newFloorObject.transform.position);
                    newFloorObject.transform.parent = floorType.transform;

                    if (showCoordsOnFloor == true)
                    {
                        GameObject newFloorCanvasObject = new()
                        {
                            name = "Canvas"
                        };
                        newFloorCanvasObject.transform.parent = newFloorObject.transform;
                        Canvas floorCanvas = newFloorCanvasObject.AddComponent<Canvas>();
                        floorCanvas.transform.localPosition = Vector3.zero;
                        floorCanvas.renderMode = RenderMode.WorldSpace;
                        floorCanvas.worldCamera = Camera.main;

                        GameObject newFloorTextObject = new()
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
                        floorText.text = "x" + x.ToString() + ",y" + z.ToString();
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
                        if (x == 0 && z != breadth - 1)
                        {
                            LineRenderer xGuideLine = newFloorObject.AddComponent<LineRenderer>();
                            if (xGuideLine != null)
                            {
                                xGuideLine.material = new Material(Shader.Find("Sprites/Default"));
                                xGuideLine.widthMultiplier = 0.04f;
                                xGuideLine.startColor = Color.cyan;
                                xGuideLine.endColor = Color.cyan;
                                xGuideLine.SetPosition(0, new Vector3(-0.5f, 0.01f, z + 0.5f));
                                xGuideLine.SetPosition(1, new Vector3(width - 0.5f, 0.01f, z + 0.5f));
                            }
                        }
                        else if (z == breadth - 1 && x != 0)
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


            //Create the game objects for the level from the prefabs
            GameObject levelObjects = new()
            {
                name = "LevelObjects"
            };
            levelObjects.transform.parent = parentGameObject.transform;
            for (int x = 0; x <= width - 1; x++)
            {
                for (int z = 0; z <= breadth - 1; z++)
                {
                    if (map[x, z] == "W")
                    {
                        //Create the border
                        GameObject prefab = Instantiate(Resources.Load<GameObject>("OutsideWall"));
                        prefab.transform.position = new Vector3(x - 0.5f, 0, z - 0.5f);
                        prefab.name = "OutsideWall_" + "x" + x + "_z" + z;
                        prefab.transform.parent = levelObjects.transform;
                    }
                    else if (map[x, z] == "w")
                    {
                        //Create an internal 'skinny' wall
                        GameObject prefab = Instantiate(Resources.Load<GameObject>("SkinnyWall"));
                        prefab.transform.position = new Vector3(x - 0.5f, 0, z - 0.5f);
                        prefab.name = "InternalSkinnyWall_" + "x" + x + "_z" + z;
                        prefab.transform.parent = levelObjects.transform;
                    }
                    else if (map[x, z] == "d")
                    {
                        //Create a 'skinny' door! 
                        GameObject prefab = Instantiate(Resources.Load<GameObject>("SkinnyDoor"));
                        prefab.transform.position = new Vector3(x - 0.5f, 0, z - 0.5f);
                        prefab.name = "InternalSkinnyDoor_" + "x" + x + "_z" + z;
                        prefab.transform.parent = levelObjects.transform;
                    }
                    else if (map[x, z] != "");
                    {
                        Debug.LogWarning("Unknown map object found, of type '" + map[x, z] + "'");
                    }
                }
            }

            //Create the start and end indicators
            GameObject startAndEndIndicators = new GameObject();
            startAndEndIndicators.name = "StartAndEndIndicators";
            startAndEndIndicators.transform.parent = parentGameObject.transform;
            GameObject startIndicatorPrefab = Instantiate(Resources.Load<GameObject>("StartArrow"));
            startIndicatorPrefab.transform.position = new Vector3(startingLocation.x, 0, startingLocation.z);
            startIndicatorPrefab.name = "StartIndicator";
            startIndicatorPrefab.transform.parent = startAndEndIndicators.transform;
            GameObject endIndicatorPrefab = Instantiate(Resources.Load<GameObject>("EndTarget"));
            endIndicatorPrefab.transform.position = new Vector3(endingLocation.x, 0, endingLocation.z);
            endIndicatorPrefab.name = "EndIndicator";
            endIndicatorPrefab.transform.parent = startAndEndIndicators.transform;

            //Create the character
            GameObject characterObject = GameObject.CreatePrimitive(PrimitiveType.Capsule);
            characterObject.transform.position = startingLocation;
            characterObject.name = "Character";
            characterObject.transform.parent = parentGameObject.transform;
            //Add the blue material to the character
            Material blueMaterial = new Material(Shader.Find("Unlit/Color"));
            blueMaterial.SetColor("_Color", Color.blue);
            characterObject.GetComponent<Renderer>().material = blueMaterial;
        }
    }
}

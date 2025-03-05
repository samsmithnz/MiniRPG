using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    public void StartGame()
    {
        Debug.Log("Loading Level 1");

        // Change the scene
        SceneManager.LoadScene("Level1");
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenLoader : MonoBehaviour
{
    public void ReloadGame()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1; //untopping the game after the game over screen
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}

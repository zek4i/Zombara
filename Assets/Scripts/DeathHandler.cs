using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    [SerializeField] Canvas gameOverCanvas;

    private void Start() 
    {
        gameOverCanvas.enabled = false; //thr game over canvaas is off at start of the game
    }
    public void HandleDeath()
    {
        gameOverCanvas.enabled = true;
        Time.timeScale = 0; //stop the game when gameover so on;y the cursor is moving and not the game
        FindObjectOfType<WeaponSwitcher>().enabled = false;
        Cursor.lockState = CursorLockMode.None; //show the cursor when game over (unlock the cursor)
        Cursor.visible = true; //make the cursor visible
    }
}

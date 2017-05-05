using UnityEngine;
using System.Collections;

public class GameSceneButtons : MonoBehaviour
{
    // the following code is referencing the canvas, canvas
    public Canvas canvas;
    
    // the following procedure is executed if the exit button is pressed
    public void ExitPressed()
    {
        // if the exit button is pressed, the line of code underneath loads the start screen
        Application.LoadLevel(0);
    }

    // the following procedure is executed if the restart button is pressed
    public void RestartButtonIsPressed()
    {
        // if the restar buttion is pressed, the line of code underneath loads the game scene again
        Application.LoadLevel(1);
    }
}

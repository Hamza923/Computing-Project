using UnityEngine;
using System.Collections;

public class gamewon : MonoBehaviour
{
    // the following code is referencing the canvas GameWon
    public Canvas GameWon;

    // the procesure underneath is run when the next level button is pressed
    public void NextLevelIsPressed()
    {
        // the line of code underneath checks whether the canvas "GameWon" enabled is true
        GameWon.enabled = true;
        // if so the code underneath loads level 2
        Application.LoadLevel(4); 
    }

    // the procedure underneath is played when the try again button is pressed
    public void TryAgainIsPressed()
    {
        // the line of code underneath checks whether the canvas "GameWon" enabled is true
        GameWon.enabled = true;
        // if so the code underneath loads the game scene
        Application.LoadLevel(1);
    }

    // the procedure underneath is played when the exit button is pressed
    public void ExitIsPressed()
    {
        // the line of code underneath checks whether the canvas "GameWon" enabled is false
        GameWon.enabled = false;
        //if so the code underneath loads the start screen
        Application.LoadLevel(0);
    }
}

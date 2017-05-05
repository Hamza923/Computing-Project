using UnityEngine;
using System.Collections;

public class gamelost : MonoBehaviour {

    // the following code is referencing the canvas GameLost
    public Canvas GameLost;

    // the procedure underneath is played when the try again button is pressed
	public void TryAgainIsPressed()
    {
        // the line of code underneath checks whether the canvas "GameLost" enabled is true
        GameLost.enabled = true;
        // if so the code underneath loads the game scene
        Application.LoadLevel(1);
    }

    // the procedure underneath is played when the exit button is pressed
    public void ExitIsPressed()
    {
        // the line of code underneath checks whther the canvas "GameLost" enabled is false
        GameLost.enabled = false;
        //if so the code underneath loads the start screen
        Application.LoadLevel(0);
    }
}

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Scenes : MonoBehaviour {

    // the following code is referencing the canvas StartScreen
    public Canvas StartScreen;

    void Awake()
    {
       
    }

    // the procedure underneath is played when the start button is pressed
    public void StartButtonPressed()
    {
        // the code below checks whether start screen being enabled is true
        StartScreen.enabled = true;
    }

    public void NotPressed()
    {
        // the code below checks whether the start screen being enables is false
        StartScreen.enabled = false;
    }

    public void Loading()
    {
        // the following code loads the game scene is the start button enabled is true
        Application.LoadLevel(1);
    }
}

using UnityEngine;
using System.Collections;

public class coins : MonoBehaviour {

    //below are four gameobjects from the hierachy in the unity application, called in this script 
    //and made public for use 
    public Transform Coins;
    public Transform Coins1;
    public Transform Coins2;
    public Transform Coins3;
    public Transform Coins4;
    public Transform Coins5;
    public Transform Robot;
    public Transform Robot2;
    public Transform Robot3;
    public Transform Robot4;

    // the code below creates a new variable for the total coins necessary for collection and sets its value to
    // 0 as default
    int TotalCoinsToWin = 0;

    // the OnCollisionEnter2D functions is used for detecting collisions between two objects
    // and the Collision2D returns the information in 2D physics
    void OnCollisionEnter2D(Collision2D Col)
    {
        // the if statement below checks whether the collision has been made with any of the coins below
            if ((Col.gameObject.name == "Coins") || (Col.gameObject.name == "Coins1") || (Col.gameObject.name == "Coins2") || (Col.gameObject.name == "Coins3") || (Col.gameObject.name == "Coins4") || (Col.gameObject.name == "Coins5"))
            {
            // if the collision has been made with the coins listed above, the following line will
            // destroy the object/coin
                Destroy(Col.gameObject);
            // after each collision the value of TotalCoinsToWin is incrimented by 1
            TotalCoinsToWin = TotalCoinsToWin + 1;

            // the if statemnt belows checks each time whether the value of TotalCoinsToWin is equal to 6 or not
            // and the current scene is the game scene
            if ((TotalCoinsToWin == 6) && (Application.loadedLevelName == "game"))
            {
                // if the value of TotalCoinsToWin is found to be 6 and the current
                // scene is the game scene, the lines underneath
                // destroy all robots
                Destroy(GameObject.Find("Robot"));
                Destroy(GameObject.Find("Robot 2"));
                Destroy(GameObject.Find("Robot 3"));
                Destroy(GameObject.Find("Robot 4")); 
                // once the robots are destroyed unity the win screen
                Application.LoadLevel(3);
            }

            if ((TotalCoinsToWin == 6) && (Application.loadedLevelName == "Level2"))
            {
                // if the value of TotalCoinsToWin is found to be 6 and the 
                // and the current scene is on level2, the lines underneath
                // destroy all robots
                Destroy(GameObject.Find("Robot"));
                Destroy(GameObject.Find("Robot 2"));
                Destroy(GameObject.Find("Robot 3"));
                Destroy(GameObject.Find("Robot 4"));
                // once the robots are destroyed unity then loads up the win screen
                Application.LoadLevel(5);
            }
        }
        }
    }


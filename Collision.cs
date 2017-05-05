using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Collision : MonoBehaviour
{
    //the player varibale below is the same from the unity application
    // called into this script for use
    public Transform player;
    // serializing X and Y makes it possible for the values to be altered within unity
    [SerializeField]
    public float X;
    [SerializeField]
    public float Y;
    // the variable below sets the defualt health of the player to 50
    [SerializeField]
    int HP;
    void OnCollisionEnter2D(Collision2D Col)
    {
        // the if statemnt checks whether a collision with the player has taken place
        if (Col.gameObject.name == "player")
        {
            // if a collision has taken place, the following line of code repositions the player to the points X and Y
            // depending on what they have been set to in unity
            player.position = new Vector2(X, Y);
            // each time a collision takes place, the code bunderneath takes away 10 from the total health
            HP = HP - 10;

            // the following if statement checks whether or not the health of the player is equal to 0
            if (HP <= 0)
            {
                // if the health is equal to 0, the code underneath destroys the player
                Destroy(Col.gameObject);
                // once the player has been destroyed unity then loads up the losing screen
                Application.LoadLevel(2);
            }
        }
    }
}

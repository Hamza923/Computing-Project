using UnityEngine;
using System.Collections;

public class WallLV2 : MonoBehaviour
{
    // the following variable will set the spped at which the walls can move
    public float wallmoveSpeed;

    // Use this for initialization
    void Start()
    {
    }
    // Update is called once per frame

    void Update()
    {
        // the following if statement checks whether the up or down arrows are pressed
        if (Input.GetKey(KeyCode.UpArrow) || (Input.GetKey(KeyCode.DownArrow)))
        {
            // if they are the code below makes it possible for the walls to move
            transform.Rotate(wallmoveSpeed * Time.deltaTime, 0, 0);
        }
    }
}


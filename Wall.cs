using UnityEngine;
using System.Collections;

public class Wall : MonoBehaviour
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
        // the following if statement checks whether the left or rigth arrows are pressed
        if (Input.GetKey(KeyCode.LeftArrow) || (Input.GetKey(KeyCode.RightArrow)))
        {
            // if they are the code below makes it possible for the walls to move
            transform.Rotate(0,  wallmoveSpeed * Time.deltaTime, 0);
        }
    }
}


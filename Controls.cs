using UnityEngine;
using System.Collections;

public class Controls : MonoBehaviour
{
    public float playermoveSpeed;
    private Animator animate;
    private bool Moving;
    private Vector2 LastMoving;
    Rigidbody2D rb;

    // Use this for initialization
    void Start()
    {
        // this gets access of the parameters in animator
        animate = GetComponent<Animator>();
        // when rb is called the the code access the Rigidbody2D of player
        rb = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame

    void Update()
    {
        // sets the velocity to 0 from start to keep player in his place
        Moving = false;
        // checks whether the "X" value is bigger than 0.5 or less than -0.5 and if the if statement is correct it performs the assigned task
        if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            //creates a new vector(x, y, z), afterwhich gains the "X" value by multiplying the "X" value to the playerspeed and then relative to real time (not frame rate). It then sets the values of "Y" and "Z" to 0
            transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * playermoveSpeed * Time.deltaTime, 0f, 0f));
            //checks whether the player is moving or not
            Moving = true;
            //gains the "X" position of the last move made by the player
            LastMoving = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
        }
        // checks whether the "Y" value is bigger than 0.5 or less than -0.5 and if the if statement is correct, performs the assigned task
        if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
        {
            //creates a new vector(x, y, z), afterwhich it sets the "X" value to 0 and gains the "Y" value by multiplying the "Y" value to the playerspeed and then relative to real time (not frame rate). It then sets the "Z" value to 0 as well
            transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * playermoveSpeed * Time.deltaTime, 0f));
            Moving = true;
            //gains the "Y" position of the last move made by the player
            LastMoving = new Vector2(0f, Input.GetAxisRaw("Vertical"));
        }
        //gets access of the MoveX parameter of animator and attches the appropiate animation
        animate.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        animate.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
        animate.SetBool("Moving", Moving);
        animate.SetFloat("LastMovingX", LastMoving.x);//i fixed this problem ok 
        animate.SetFloat("LastMovingY", LastMoving.y);
    }

    public void MoveRight()
    {
        // the code below adds movement to the player when the right arrow (touch control) is pressed
        rb.velocity = new Vector2(playermoveSpeed, 0);
    }
    public void MoveLeft()
    {
        // the code below adds movement to the player when the left arrow (touch control) is pressed
        rb.velocity = new Vector2(-playermoveSpeed, 0);

    }
    public void MoveUp()
    {
        // the code below adds movement to the player when the up arrow (touch control) is pressed
        rb.velocity = new Vector2(0, playermoveSpeed);

    }
    public void MoveDown()
    { 
        // the code below adds movement to the player when the down arrow (touch control) is pressed
        rb.velocity = new Vector2(0, -playermoveSpeed);

    }
    public void NoVelocity()
    {
        //the code underneath sets the velocity to 0 when nothing is pressed
        rb.velocity = Vector2.zero;

    }
}


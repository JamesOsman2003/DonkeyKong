using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private int Input_Up = 0;
    private int Input_Down = 0;
    private int Input_Left = 0;
    private int Input_Right = 0;
    private int Vertical_Input = 0;
    private int Horizontal_Input = 0;

    [SerializeField] private LayerMask platformLayer;
    private bool isGrounded = false;
    private Rigidbody2D rb;

    private bool Jumping = false;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        Vector2 test = transform.position;
        RaycastHit2D TestRay = Physics2D.Raycast(test, Vector2.down,0.1f,platformLayer);
        if (TestRay.collider != null)
        {
            Debug.DrawRay(test, (Vector2.down) * 0.1f, Color.green);
            isGrounded = true;
            Jumping = false;
            //Debug.Log("Grounded");
        }
        else
        {
            Debug.DrawRay(test, (Vector2.down) * 0.1f, Color.magenta);
            isGrounded = false;
            //Debug.Log("inAir");
        }
        //Movement Inputs -- W A S D , U_A L_A D_A R_A
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            Input_Up = 1;
        }
        else Input_Up = 0;

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            Input_Down = 1;
        }
        else Input_Down = 0;

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            Input_Left = 1;
        }
        else Input_Left = 0;

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            Input_Right = 1;
        }
        else Input_Right = 0;

        Vertical_Input = Input_Up - Input_Down;
        Horizontal_Input = Input_Right - Input_Left;

        if (Jumping != true && isGrounded == true)
        {
            if (Input.GetKey(KeyCode.Space))
                Jump(); 
        }
        
        //Debug.Log((Vertical_Input, Horizontal_Input));
        
    }
    void Jump()
    {
        Debug.Log("Jump");
            //rb.AddForce((Vector2.up)*100,ForceMode2D.Force);
            rb.velocity = new Vector2(rb.velocity.x, 10);
            Jumping = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent (typeof (Rigidbody))]
public class PlayerController : IAttack, IJump, IFlip
{
    public GameObject player;
    public Vector3 jump;
    public float jumpForce;
    public bool isGrounded;
    Rigidbody rigidBody;
    public int playerPower;
    int buttonPressedCounter = 0;
    void Start ()
    {
        rigidBody = GetComponent<Rigidbody> ();
        jump = new Vector3 (0.0f, 2.0f, 0.0f);

    }
    void OnCollisionStay ()
    {
        isGrounded = true;
    }
    private void Update ()
    {
        Jump ();
        Duck ();
    }

    public void Jump ()
    {
        if (Input.GetKey ("up") && isGrounded)
        {
            rigidBody.AddForce (jump * jumpForce, ForceMode.Impulse);
            Flip ();
            if (Input.GetKeyDown ("down"))
                DivingAttack ();

        }
    }
    public void Duck ()
    {
        if (Input.GetKey ("down") && isGrounded)
        {
            buttonPressedCounter++;
            isGrounded = true;
            transform.position += Vector3.down * Time.deltaTime;
            if (buttonPressedCounter == 5)
                GainPower (100);
            else
                //assume that 10 is a defult power 
                GainPower (10);

        }
    }
    public void Flip ()
    {
        transform.RotateAround (player.transform.position, new Vector3 (0, 20, 20), 100 * Time.deltaTime);

    }
    public void GainPower (int power)
    {
        if (Input.GetKeyDown ("space"))
        {
            playerPower += power;
        }
    }

    public void DivingAttack ()
    {

        //play  diving attack animation here
        Debug.Log (" diving attack");

    }
}
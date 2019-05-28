using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public bool onTheWall = false;
    public int stamina = 10;
    public int sleepiness = 0;
    public float normalSpeed = 10.0f;
    public int Cooltime = 5;
    public int witecount = 0;
    float speed = 0.0f;
    float fatigue = 0.0f;

    // Update is called once per frame
    void Update()
    {

        SpeedCalculator();

        if (Cooltime == 0)
        {
            if (stamina < 10)
            {
                stamina++;
            }
        }
        InputMove();
    }

    void SpeedCalculator()
    {
        if (stamina == 10)
        {
            fatigue = 1.0f;
        }
        if (stamina <= 7)
        {
            fatigue = 0.9f;
        }
        if (stamina <= 3)
        {
            fatigue = 0.7f;
        }
        if (stamina == 1)
        {
            fatigue = 0.5f;
        }

        speed = normalSpeed * fatigue;
    }

    void InputMove()
    {
        Rigidbody myRigid = GetComponent<Rigidbody>();
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.Keypad4))
        {
            myRigid.AddForce(new Vector3(speed, 0, 0));
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.Keypad6))
        {
            myRigid.AddForce(new Vector3(-speed, 0, 0));
        }
        if (onTheWall == true)
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Keypad8))
            {
                myRigid.AddForce(new Vector3(0, 0, -speed));
            }
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.Keypad2))
            {
                myRigid.AddForce(new Vector3(0, 0, speed));
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Keypad8))
            {
                myRigid.AddForce(new Vector3(0, speed, 0));
            }
        }
    }
}

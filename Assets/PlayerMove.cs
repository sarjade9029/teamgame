using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public bool onTheWall = false;
    public int stamina = 10;
    public int sleepiness = 0;
    public float speed = 10.0f;

    // Update is called once per frame
    void Update()
    {
        Rigidbody myRigid = GetComponent<Rigidbody>();
        if(onTheWall == false)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                myRigid.AddForce(new Vector3(0, speed, 0));
            }
        }
        if (Input.GetKey(KeyCode.A))
        {
            myRigid.AddForce(new Vector3(speed, 0, 0));
        }
        if (Input.GetKey(KeyCode.D))
        {
            myRigid.AddForce(new Vector3(-speed, 0, 0));
        }
        if(onTheWall == true)
        {
            if (Input.GetKey(KeyCode.W))
            {
                myRigid.AddForce(new Vector3(0, 0, -speed));
            }
            if (Input.GetKey(KeyCode.S))
            {
                myRigid.AddForce(new Vector3(0, 0, speed));
            }
        }

    }
}

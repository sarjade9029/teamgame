using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Player player = new Player();
    float speed = 0.0f;                     //移動速度:最終的な移動速度この値が移動速度になる
    float fatigue = 1.0f;                   //疲労:この数値をかけてスピードを調整する
    // Update is called once per frame
    void Update()
    {
        SpeedCalculator();
        if (player.Cooltime == 0)
        {
            if (player.stamina < 10)
            {
                player.stamina++;
            }
        }
        InputMove();
    }
    //スピード計算
    void SpeedCalculator()
    {
        if (player.stamina <= 10 && player.stamina >= 8)
        {
            fatigue = 1.0f;
        }
        if (player.stamina <= 7 && player.stamina >= 4)
        {
            fatigue = 0.9f;
        }
        if (player.stamina <= 3)
        {
            fatigue = 0.7f;
        }

        speed = player.normalSpeed * fatigue;

    }
    //キー入力
    void InputMove()
    {
        Rigidbody myRigid = GetComponent<Rigidbody>();
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) )
        {
            myRigid.AddForce(new Vector3(speed, 0, 0));
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) )
        {
            myRigid.AddForce(new Vector3(-speed, 0, 0));
        }
        if (player.onTheWall == true)
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                myRigid.AddForce(new Vector3(0, 0, -speed));
            }
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow) )
            {
                myRigid.AddForce(new Vector3(0, 0, speed));
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.Space))
            {
                player.onTheWall = true;
            }
        }
    }
}

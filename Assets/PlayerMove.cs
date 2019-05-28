using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public bool onTheWall = false;          //壁に張り付いている状態か
    public int stamina = 10;                //スタミナ:減ると特種行動ができなくなる
    public int sleepiness = 0;              //眠気:蓄積されると移動が遅くなる
    public float normalSpeed = 10.0f;       //移動速度:通常の移動速度
    public int Cooltime = 5;                //クールタイム:スタミナが0になると発生する
    public int witecount = 10;              //スタミナが1回復するまでの時間(フレーム)

    float speed = 0.0f;                     //移動速度:最終的な移動速度この値が移動速度になる
    float fatigue = 1.0f;                   //疲労:この数値をかけてスピードを調整する

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
    //スピード計算
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
        if (onTheWall == true)
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
                onTheWall = true;
            }
        }
    }
}

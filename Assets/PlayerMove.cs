using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Condition
{
    public int staminamax;
    public float fatigue;
};

public class PlayerMove : MonoBehaviour
{
    public int Cooltime = 5;                //クールタイム:スタミナが0になると発生する
    public int witecount = 10;              //スタミナが1回復するまでの時間(フレーム)
    public int stamina = 10;                //スタミナ:減ると特種行動ができなくなる
    public int sleepiness = 0;              //眠気:蓄積されると移動が遅くなる
    public bool onTheWall = false;          //壁に張り付いている状態か
    public float normalSpeed = 10.0f;       //移動速度:通常の移動速度
    //public float tonguelength = 5.0f;       //舌の判定の長さ

    //public float 
    //public float
    //Player player = new Player();
    float speed = 0.0f;                     //移動速度:最終的な移動速度この値が移動速度になる
    float fatigue = 1.0f;                   //疲労:この数値をかけてスピードを調整する
    static int con = 3;
    Condition[] conditions = new Condition[con];
    void Start()
    {
        for (int i = 0; i < con; i++) 
        {
            conditions[i] = new Condition() { staminamax = (i + 1) * 3, fatigue = 1.0f - (0.1f * (i+1)) };
        }
    }

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
        
        fatigue = 1.0f;
        for (int i = 0; i < con; i++)
        {
            //マックス値以下なら疲労を代入
            if(stamina < conditions[i].staminamax)
            {
                fatigue = conditions[i].fatigue;
            }
        }
        
            speed = normalSpeed * fatigue;
        

    }
    //キー入力
    void InputMove()
    {
        
        Rigidbody2D myRigid = GetComponent<Rigidbody2D>();
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) )
        {
            transform.localScale = new Vector3(-1, 1, 1);
            myRigid.AddForce(new Vector3(-speed, 0, 0));
        }
        if(Input.GetKeyUp(KeyCode.A)|| Input.GetKeyUp(KeyCode.LeftArrow))
        {
            Stop();
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) )
        {
            transform.localScale = new Vector3(1, 1, 1);
            myRigid.AddForce(new Vector3(speed, 0, 0));
        }
        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            Stop();
        }
        if (onTheWall == true)
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                myRigid.AddForce(new Vector3(0, -speed, 0));
            }
            if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow))
            {
                Stop();
            }
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow) )
            {
                myRigid.AddForce(new Vector3(0, speed, 0));
            }
            if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow))
            {
                Stop();
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

    void Stop()
    {
        Rigidbody2D myRigid = GetComponent<Rigidbody2D>();
        myRigid.velocity = Vector2.zero;
        //myRigid.angularVelocity = Vector3.zero;
    }

}

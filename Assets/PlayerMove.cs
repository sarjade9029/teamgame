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
        var player = gameObject.AddComponent<Player>();
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
        var player = gameObject.AddComponent<Player>();
        fatigue = 1.0f;
        for (int i = 0; i < con; i++)
        {
            //マックス値以下なら疲労を代入
            if(player.stamina < conditions[i].staminamax)
            {
                fatigue = conditions[i].fatigue;
            }
        }

        speed = player.normalSpeed * fatigue;

    }
    //キー入力
    void InputMove()
    {
        var player = gameObject.AddComponent<Player>();
        Rigidbody2D myRigid = GetComponent<Rigidbody2D>();
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) )
        {
            transform.localScale = new Vector3(1, 1, 1);
            myRigid.AddForce(new Vector3(-speed, 0, 0));
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) )
        {
            transform.localScale = new Vector3(-1, 1, 1);
            myRigid.AddForce(new Vector3(speed, 0, 0));
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

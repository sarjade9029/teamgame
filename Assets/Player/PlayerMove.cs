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
    public int Cooltime = 5;                                        //クールタイム:スタミナが0になると発生する
    public int stamina = 10;                                        //スタミナ:減ると隠れることができなくなる
    public int witecount = 10;                                      //スタミナが1回復するまでの時間(フレーム)
    public int sleepiness = 10;                                     //眠気:蓄積されると移動が遅くなる
    public float rot = 0;
    public float rigortime = 30;
    public float posSpeed = 0.01f;
    public float normalSpeed = 10.0f;                               //移動速度:通常の移動速度
    public bool movement = false;
    private int count = 30;
    private float joysticky;
    private float joystickx;
    private float prevrotz = 0;
    private float prevscalex = 1;
    private float fatigue = 1.0f;                                   //疲労:この数値をかけてスピードを調整する
    private float addSpeed = 0.0f;                                  //移動速度:最終的な移動速度この値が移動速度になる
    private bool move = false;
    private bool onTheWall = false;                                 //壁に張り付いている状態か
    private bool onTheGround = true;
    private bool inputAbort = false;
    static private int coin = 0;
    static private int score = 0;
    static readonly int con = 3;
    private bool havekey = false;
    readonly Condition[] conditions = new Condition[con];
    [SerializeField] Animator anim;
    [SerializeField] GameObject player;
    private void Start()
    {
        for (int i = 0; i < con; i++)
        {
            conditions[i] = new Condition() { staminamax = (i + 1) * 3, fatigue = 1.0f - (0.1f * (i + 1)) };
        }
    }
    private void Update()
    {
        if (rot >= 360 || rot <= -360 || onTheWall == false)
        {
            rot = 0;
            prevrotz = 0;
        }
        SpeedCalculator();
        if (Cooltime == 0)
        {
            if (stamina < 10)
            {
                stamina++;
            }
        }
        if (inputAbort == false)
        {
            InputMove();
        }
        if (movement == false || joystickx == 0 || joysticky == 0)
        {
            Stop();
        }
    }
    //スピード計算
    private void SpeedCalculator()
    {
        fatigue = 1.0f;
        for (int i = 0; i < con; i++)
        {
            //マックス値以下なら疲労を代入
            if (stamina < conditions[i].staminamax)
            {
                fatigue = conditions[i].fatigue;
            }
        }
        addSpeed = (normalSpeed * fatigue) / 100;
    }
    //1,1右上  1,-1右下  -1,1左上  -1,-1左下
    //キー入力(斜めなし)
    private void InputMove()
    {
        Rigidbody2D myRigid = GetComponent<Rigidbody2D>();
        joystickx = Input.GetAxis("Horizontal");
        joysticky = Input.GetAxis("Vertical");
        //if (count == rigortime)
        //{
        //左
        if (Input.GetKey(KeyCode.A) ||
            Input.GetKey(KeyCode.LeftArrow) ||
            ((joystickx < 0) && (joysticky <= 0.5f) && (joysticky >= -0.5f)))
        {
            movement = true;
            if (onTheWall == false)
            {
                //動きを遅くするか止める
                transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
                transform.position += new Vector3(-posSpeed, 0.0f, 0.0f);
                prevscalex = transform.localScale.x;
            }
            else
            {
                //動きを遅くするか止める
                transform.position += new Vector3(-posSpeed, 0.0f, 0.0f);
                player.transform.rotation = Quaternion.AngleAxis(90, new Vector3(0, 0, 1));
                prevrotz = player.transform.localRotation.z;
            }
        }
        if (Input.GetKeyUp(KeyCode.A) ||
            Input.GetKeyUp(KeyCode.LeftArrow))
        {
            movement = false;
        }
        //右
        if (/*Input.GetKey(KeyCode.D) ||
        I   nput.GetKey(KeyCode.RightArrow) ||*/
            ((joystickx > 0) && (joysticky <= 0.5f) && (joysticky >= -0.5f)))
        {
            movement = true;
            if (onTheWall == false)
            {
                //動きを遅くするか止める
                transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                transform.position += new Vector3(posSpeed, 0.0f, 0.0f);
                prevscalex = transform.localScale.x;
            }
            else
            {
                //動きを遅くするか止める
                transform.position += new Vector3(posSpeed, 0.0f, 0.0f);
                player.transform.rotation = Quaternion.AngleAxis(-90, new Vector3(0, 0, 1));
                prevrotz = player.transform.localRotation.z;
            }
        }
        if (Input.GetKeyUp(KeyCode.D) ||
            Input.GetKeyUp(KeyCode.RightArrow))
        {
            movement = false;
        }
        //上
        if (/*Input.GetKey(KeyCode.W) ||
            Input.GetKey(KeyCode.UpArrow) ||*/
            ((joysticky > 0) && (joystickx <= 0.5f) && (joystickx >= -0.5f)))
        {
            movement = true;
            if (onTheWall == false)
            {
                transform.position += new Vector3(0.0f, posSpeed, 0.0f);
            }
            else
            {
                //動きを遅くするか止める
                transform.position += new Vector3(0.0f, posSpeed, 0.0f);
                player.transform.rotation = Quaternion.AngleAxis(0, new Vector3(0, 0, 1));
                prevrotz = player.transform.localRotation.z;
            }
        }
        if (Input.GetKeyUp(KeyCode.W) ||
            Input.GetKeyUp(KeyCode.UpArrow))
        {
            movement = false;
        }
        //下
        if (/*Input.GetKey(KeyCode.S) ||
            Input.GetKey(KeyCode.DownArrow) ||*/
            ((joysticky < 0) && (joystickx <= 0.5f) && (joystickx >= -0.5f)))
        {
            movement = true;
            if (onTheWall == true)
            {
                //動きを遅くするか止める
                transform.position += new Vector3(0.0f, -posSpeed, 0.0f);
                player.transform.rotation = Quaternion.AngleAxis(180, new Vector3(0, 0, 1));
                prevrotz = player.transform.localRotation.z;
            }
        }
        if (Input.GetKeyUp(KeyCode.S) ||
            Input.GetKeyUp(KeyCode.DownArrow))
        {
            movement = false;
        }
        anim.SetBool("Walk", movement);
    }
    public void Stop()
    {
        Rigidbody2D myRigid = GetComponent<Rigidbody2D>();
        myRigid.velocity = Vector2.zero;
        movement = false;
    }
    public void OnWall()
    {
        onTheWall = true;
    }
    public void OnGround()
    {
        onTheGround = true;
    }
    public void LeaveWall()
    {
        onTheWall = false;
    }
    public void LeaveGround()
    {
        onTheGround = false;
    }
    public void InputAbort()
    {
        inputAbort = true;
    }
    public void InputPermit()
    {
        inputAbort = false;
    }
    public bool GetOnGround()
    {
        return onTheGround;
    }
    public int GetScore()
    {
        return score;
    }
    public void AddScore(int n)
    {
        score += n;
    }
    public int GetCoin()
    {
        return coin;
    }
    public void AddCoin(int n)
    {
        coin += n;
    }
    public void GetKey()
    {
        havekey = true;
    }
    public bool GetKeyState()
    {
        return havekey;
    }
    private void Stopmove()
    {
        count = 0;
        move = true;
    }
    public void scorecoininit()
    {
        coin = 0;
        score = 0;
    }
}

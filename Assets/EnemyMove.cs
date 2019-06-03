using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public bool firstMove = true;               //移動時の方向転換用
    public bool leftMove = true;                //移動方向転換
    public int startMoveTime = 5;               //最初の一回の一定方向に移動する時間
    public int moveTime = 10;                   //一定方向に移動する時間
    public int shot = 3;                        //弾数もしかしたら画面上の最大数になる
    public int shotIntervalCount = 15;          //次の弾を撃つまでの時間
    public int reroadTime = 30;                 //弾を打ち切った時の間
    public float normalSpeed = 8.0f;            //移動速度:通常の移動速度
    public float shotSpeed = 8.0f;              //弾の速度
    public float moveSpeed = 5.0f;              //移動速度

    float speed = 0.0f;                         //

    void Move()
    {
        Rigidbody myRigid = GetComponent<Rigidbody>();
        //左右移動
        if (firstMove == true)
        {
            for (int i = 0; i <= startMoveTime; i++)
            {
                myRigid.AddForce(new Vector3(speed, 0, 0));
            }
            firstMove = false;
            leftMove = false;
        }

        if (leftMove)
        {
            for (int i = 0; i <= moveTime; i++)
            {
                myRigid.AddForce(new Vector3(speed, 0, 0));
            }
            leftMove = false;
        }
        else
        {
            for (int i = 0; i <= moveTime; i++)
            {
                myRigid.AddForce(new Vector3(-speed, 0, 0));
            }
            leftMove = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Move();

    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyMove : MonoBehaviour
{
    private Rigidbody2D rigidbody2d = null;             //敵を移動させる
    private SpriteRenderer spriterenderer = null;       //カメラに写っている間だけ動く
    public bool leftMove = false;                       //移動方向転換
    private int moveingTime = 0;                        //動いた時間
    public int moveTime = 600;                          //一定方向に移動する時間
    public float moveSpeed = 1.0f;                      //移動速度
    float speed = 0.0f;                                 //スピードの値
    private bool move = true;                           //動いているかどうか
    public Animator animator;                           //アニメーション
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        spriterenderer = GetComponent<SpriteRenderer>();
    }
    void Move()
    {
        if (move == true)
        {
            if (spriterenderer.isVisible)
            {
                speed = moveSpeed;
                int xVector = 1;
                //左右移動
                if (leftMove)
                {
                   xVector = -1;
                   transform.localScale = new Vector3(1, 1, 1);
                    if (moveingTime == moveTime)
                    {
                        leftMove = false;
                        moveingTime = 0;
                    }
                }
                else
                {
                   transform.localScale = new Vector3(-1, 1, 1);
                    if (moveingTime == moveTime)
                    {
                        leftMove = true;
                        moveingTime = 0;
                    }
                }
                rigidbody2d.velocity = new Vector2(xVector * speed, 0);
                moveingTime++;
            }
        }
    }
    void Update()
    {
        if (moveSpeed < 1 && moveSpeed > -1)
        {
            move = false;
        }
        Move();
        animator.SetBool("Walk", move);
    }
    public void Stop()
    {
        move = false;
    }
    public void ParmitMove()
    {
        move = true;
    }
}
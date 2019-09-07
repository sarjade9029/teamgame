﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyMove : MonoBehaviour
{
    private Rigidbody2D rb = null;
    private SpriteRenderer sr = null;
    public bool leftMove = false;                //移動方向転換
    private int moveingTime = 0;
    public int moveTime = 600;                  //一定方向に移動する時間
    public float moveSpeed = 1.0f;              //移動速度
    float speed = 0.0f;                         //
    private bool move = true;
    public Animator anim;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }
    void Move()
    {
        //ifが動いていない
        if (move == true)
        {
            if (sr.isVisible)
            {
                speed = moveSpeed;
                Rigidbody2D myRigid = GetComponent<Rigidbody2D>();
                //左右移動
                int xVector = 1;
                if(leftMove)
                {
                   xVector = -1;
                   transform.localScale = new Vector3(1, 1, 1);
                   if(moveingTime == moveTime)
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
                rb.velocity = new Vector2(xVector * speed, 0);
                moveingTime++;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (moveSpeed < 1 && moveSpeed > -1)
        {
            move = false;
        }
        Move();
        anim.SetBool("Walk", move);
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
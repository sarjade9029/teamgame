﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour
{
    float startTime;
    public float xSpeed = 5.0f;
    public int dmg = 1;
    GameObject Player;
    PlayerMove Playermove;
    private float playerpos;
    // Use this for initialization
    void Start()
    {
        Player = GameObject.Find("player1");
        Playermove = Player.GetComponent<PlayerMove>();
        playerpos = Player.transform.localPosition.y;
        startTime = Time.time;
    }
    // Update is called once per frame
    void Update()
    {
        Rigidbody2D myRigid = GetComponent<Rigidbody2D>();
        // 現在時刻から開始時刻を引くと、開始から経過時間がとれる
        // それが5秒より大きいとき自殺する
        if (Time.time - startTime > 2.0f)
        {
            Destroy(gameObject);
        }

        // たまが反対を向いている（スケールがマイナス）なら反対に進ませる
        if (transform.localScale.x < 0)
        {
            //右向き
            if(playerpos>=-5&&playerpos<=-2)
            {
                myRigid.velocity = transform.right * xSpeed;
            }
            if (playerpos > -2 && playerpos < 2)
            {
                myRigid.velocity = new Vector2(xSpeed * 0.7f, xSpeed * 0.7f);
            }
            if (playerpos >= 2 && playerpos <= 4)
            {
                myRigid.velocity = transform.up * xSpeed;
            }
        }
        else
        {
            //左向き
            if (playerpos >= -5 && playerpos <= -2)
            {
                myRigid.velocity = -transform.right * xSpeed;
            }
            if (playerpos > -2 && playerpos < 2)
            {
                myRigid.velocity = new Vector2(-xSpeed * 0.7f, xSpeed * 0.7f);
            }
            if (playerpos >= 2 && playerpos <= 4)
            {
                myRigid.velocity = transform.up * xSpeed;
            }
        }


    }



    //以下不変
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            //使うステを取る
            if(Playermove.GetOnGround()==true)
            {
                PlayerMove player = other.gameObject.GetComponent<PlayerMove>();
                //体力減らす
                player.sleepiness -= dmg;
                if (player.sleepiness == 0)
                {
                    Destroy(other.gameObject);
                }
                Destroy(gameObject);
            }
            else
            {
                //体力減らす
                Playermove.sleepiness -= dmg;
                if (Playermove.sleepiness == 0)
                {
                    Destroy(other.gameObject);
                }
                Destroy(gameObject);
            }
        }
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAtack : MonoBehaviour
{
    //挙動
    float tongueLength = 0;             //舌を伸ばす距離を時間で割った数を入れる
    public float tongueScale = 1.0f;         //舌を伸ばす距離
    public float extendTime = 1.0f;     //時間
    bool extend = false;
    GameObject player;
    PlayerMove playerscript;
    SetTomgue tonglescript;
    Hide hide;
    void Start()
    {
        player = GameObject.Find("player1");
        playerscript = player.GetComponent<PlayerMove>();
        tonglescript = player.GetComponent<SetTomgue>();
        hide = player.GetComponent<Hide>();
    }
    // Update is called once per frame
    void Update()
    {
        TongueExtend();
    }
    void TongueExtend()
    {
        playerscript.Stop();
        playerscript.InputAbort();
        if(extend==false)
        {
            if (transform.localScale.x < 0)
            {
                tongueLength -= tongueScale / extendTime;
            }
            else
            {
                tongueLength += tongueScale / extendTime;
            }
            transform.localScale = new Vector3(tongueLength, 1.0f, 1.0f);
            
        }
        else
        {
            if(transform.localScale.x<0)
            {
                tongueLength += tongueScale / extendTime;
            }
            else
            {
                tongueLength -= tongueScale / extendTime;
            }
            transform.localScale = new Vector3(tongueLength, 1.0f, 1.0f);
        }
        if ((tongueScale <= tongueLength && player.transform.localScale.x > 0)
           || (-tongueScale >= tongueLength && player.transform.localScale.x < 0))
        {
            extend = true;
        }
        if ((tongueLength <= 0.0f && player.transform.localScale.x > 0)
            || (tongueLength >= 0.0f && player.transform.localScale.x < 0))
        {
            //キー入力の許可
            playerscript.inputPermit();
            //次の舌を出す許可
            tonglescript.ExtendEnd();
            //攻撃終了の通知関数
            hide.MimicryOn();
            Destroy(gameObject);
        }
    }
}

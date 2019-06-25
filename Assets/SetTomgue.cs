﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTomgue : MonoBehaviour
{
    //生成
    public GameObject Tongue;
    public GameObject PlayerPos;
    private bool extend = false;
    GameObject player;
    Hide hide;
    // Update is called once per frame
    void Update()
    {
        //player = GameObject.Find("player1");
        hide = GetComponent<Hide>();
        KeyInput();
    }
    void KeyInput()
    {
        if (Input.GetKeyDown(KeyCode.E) && extend == false)
        {
            extend = true;
            //ここに攻撃開始の通知関数を入れる
            hide.MimicryOff();
            GameObject newAttack = GameObject.Instantiate(Tongue);

            newAttack.transform.position = 
                new Vector3(PlayerPos.transform.position.x,
                PlayerPos.transform.position.y,
                PlayerPos.transform.position.z + 1);

            //向きを同じにする
            //newAttack.transform.rotation = gameObject.transform.rotation;
            if (PlayerPos.transform.localScale.x < 0) 
            {
                newAttack.transform.localScale = 
                    new Vector3(0.01f*-1
                    ,PlayerPos.transform.localScale.y
                    ,PlayerPos.transform.localScale.z);
            }
        }
    }
    public void ExtendEnd()
    {
        extend = false;
    }
}

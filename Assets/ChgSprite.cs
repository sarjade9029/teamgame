﻿//未使用
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChgSprite : MonoBehaviour
{
    public float zero = 0;//0
    public float alpha = 1;//1
    public GameObject spriteMae;
    public GameObject spriteNak;
    public GameObject spriteAto;
    public GameObject player;
    Image down;
    Image sleep;
    Image normal;
    PlayerMove playerMove;
    void Start()
    {
        playerMove = player.GetComponent<PlayerMove>();
        normal = spriteMae.GetComponent<Image>();
        sleep = spriteNak.GetComponent<Image>();
        down = spriteAto.GetComponent<Image>();
    }
    void Update()
    {
        if (playerMove.sleepiness <= 10 && playerMove.sleepiness > 7 )
        {
            normal.color = new Color(1, 1, 1, alpha);
            sleep.color = new Color(1, 1, 1, zero);
            down.color = new Color(1, 1, 1, zero);
        }
        else if (playerMove.sleepiness <= 7 && playerMove.sleepiness > 3  )
        {
            normal.color = new Color(1, 1, 1, zero);
            sleep.color = new Color(1, 1, 1, alpha);
            down.color = new Color(1, 1, 1, zero);
        }
        else if (playerMove.sleepiness <= 3)
        {
            normal.color = new Color(1, 1, 1, zero);
            sleep.color = new Color(1, 1, 1, zero);
            down.color = new Color(1, 1, 1, alpha);
        }
    }
}
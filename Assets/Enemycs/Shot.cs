﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    public bool shotflag = false;    //そもそも球を撃つかどうか
    private float time = 0;          //弾を撃った後の待機時間
    GameObject parent;               //アニメーションを取得する場所
    [SerializeField] Animator animator;
    [SerializeField] GameObject shotPoint;     //ショットを生み出す場所
    [SerializeField] GameObject shotPrefab;    //生み出すもととなる弾のプレハブ
    void Start()
    {
        parent = shotPoint.transform.root.gameObject;
        animator = parent.GetComponent<Animator>();
    }
    void Update()
    {
        if (shotflag == true)
        {
            if(shotPrefab.tag != "enemy2")
            {
                animator.SetTrigger("Attack");
            }
            if (time == 0)
            {
                GameObject newShot = GameObject.Instantiate(shotPrefab);
                newShot.transform.position = shotPoint.transform.position;
                if (shotPoint.transform.localScale.x < 0)
                {
                    newShot.transform.localScale =
                        new Vector3(newShot.transform.localScale.x * -1,
                                    newShot.transform.localScale.y,
                                    newShot.transform.localScale.z);
                }
                time = 180;
            }
            if (time > 0)
            {
                time--;
            }
        }
    }
    public void ResetTime()
    {
        time = 0;
    }
}
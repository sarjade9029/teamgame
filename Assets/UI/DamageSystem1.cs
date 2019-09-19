using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class DamageSystem1 : MonoBehaviour
{
    [SerializeField] int maxHP = 13;
    [SerializeField] float currentHP;//現在値
    GameObject textObj;
    [SerializeField] Text text;
    [SerializeField] GameObject hpSystem;
    [SerializeField] GameObject player;
    PlayerMove playerhp;
    void Start()
    {
        //TextをGameObjectとして取得する
        textObj = GameObject.Find("Text");
        //HPSystemを取得する
        hpSystem = GameObject.Find("HPSystem");
        player = GameObject.Find("player1");
        playerhp = player.GetComponent<PlayerMove>();
    }
    void Update()
    {
        //TextのTextコンポーネントにアクセス
        //(int)はfloatを整数で表示するためのもの
        textObj.GetComponent<Text>().text = ((int)currentHP).ToString();
        //HPSystemのスクリプトのHPDown関数に2つの数値を送る
        hpSystem.GetComponent<HPSystem>().HPDown(currentHP, maxHP);
    }
    void FixedUpdate()
    {
        //currentHPが0以上ならTrue
        if (0 <= currentHP)
        {
            //maxHPから秒数（×10）を引いた数がcurrentHP
            currentHP = playerhp.sleepiness;
        }
    }
}

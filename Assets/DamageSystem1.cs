using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class DamageSystem1 : MonoBehaviour
{

    [SerializeField]
    int maxHP = 100;

    [SerializeField]
    float currentHP;//現在値


    GameObject textObj;
    Text text;
    GameObject hpSystem;

    //１の時は〇 100%の状態　max
    //0.75画像の75％の状態　現在値
    //画像の加工すべき場所は右下を削り取る
    //rotation Zを270もしくは-90にする

    // Start is called before the first frame update
    void Start()
    {

        //TextをGameObjectとして取得する
        textObj = GameObject.Find("Text");
        //HPSystemを取得する
        hpSystem = GameObject.Find("HPSystem");


    }

    // Update is called once per frame
    void Update()
    {

        //TextのTextコンポーネントにアクセス
        //(int)はfloatを整数で表示するためのもの
        textObj.GetComponent<Text>().text = ((int)currentHP).ToString();

        //HPSystemのスクリプトのHPDown関数に2つの数値を送る
        hpSystem.GetComponent<HPSystem>().HPDown(currentHP, maxHP);

    }

    //FixedUpdateは一定に呼ばれるので持続的に使う処理に良いらしい
    void FixedUpdate()
    {
        //currentHPが0以上ならTrue
        if (0 <= currentHP)
        {
            //maxHPから秒数（×10）を引いた数がcurrentHP
            currentHP = maxHP - Time.time * 10;





        }
    }
}

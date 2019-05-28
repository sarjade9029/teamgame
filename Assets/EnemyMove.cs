using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public int moveTime = 5;                    //一定方向に移動する時間
    public int shot = 3;                        //弾数もしかしたら画面上の最大数になる
    public int shotIntervalCount = 15;          //次の弾を撃つまでの時間
    public int reroadTime = 30;                 //弾を打ち切った時の間
    public float normalSpeed = 8.0f;            //移動速度:通常の移動速度
    public float shotSpeed = 8.0f;              //弾の速度

    float speed = 0.0f;                         //
    

    // Update is called once per frame
    void Update()
    {
        //左右移動

    }
}

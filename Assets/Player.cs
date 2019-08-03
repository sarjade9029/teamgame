using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int Cooltime = 5;                //クールタイム:スタミナが0になると発生する
    public int witecount = 10;              //スタミナが1回復するまでの時間(フレーム)
    public int stamina = 10;                //スタミナ:減ると特種行動ができなくなる
    public int sleepiness = 0;              //眠気:蓄積されると移動が遅くなる
    public bool onTheWall = false;          //壁に張り付いている状態か
    public float normalSpeed = 10.0f;       //移動速度:通常の移動速度
    public float tonguelength = 5.0f;       //舌の判定の長さ

    //public float 
    //public float

    


    // Update is called once per frame
    void Update()
    {

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAtack : MonoBehaviour
{
    float tongueLength = 0;             //舌を伸ばす距離を時間で割った数を入れる
    private float tongueScale = 1.0f;   //舌を伸ばす距離
    public float extendTime = 1.0f;     //時間
    bool extend = false;                //伸ばしている途中か？
    public float animtime = 120;
    public float count = 0;
    public bool hit = false;
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
        if (extend == false)
        {
            if (transform.localScale.x < 0)
            {
                //マイナス方向を向いているなら
                tongueLength -= tongueScale / extendTime;
                //マイナス方向に伸ばす
            }
            else
            {
                //プラス方向を向いているなら
                tongueLength += tongueScale / extendTime;
                //プラス方向に伸ばす
            }
            transform.localScale = new Vector3(tongueLength, 1.0f, 1.0f);
            //向いている方向に伸ばす
        }
        else
        {
            if (transform.localScale.x < 0)
            {
                //マイナス方向を向いているなら
                tongueLength += tongueScale / extendTime;
                //プラス方向に縮める
            }
            else
            {
                //プラス方向を向いているなら
                tongueLength -= tongueScale / extendTime;
                //マイナス方向に縮める
            }
            transform.localScale = new Vector3(tongueLength, 1.0f, 1.0f);
            //向いている方向に縮める
        }
        if ((tongueScale <= tongueLength && player.transform.localScale.x > 0)//プラス方向に伸びきったとき
           || (-tongueScale >= tongueLength && player.transform.localScale.x < 0))//マイナス方向に伸びきったとき
        {
            extend = true;
        }
        if ((tongueLength <= 0.0f && player.transform.localScale.x > 0)
            || (tongueLength >= 0.0f && player.transform.localScale.x < 0))
        {
            if (count >= animtime || hit == false)
            {
                //キー入力の許可
                playerscript.InputPermit();
                //次の舌を出す許可
                tonglescript.ExtendEnd();
                //攻撃終了の通知関数
                hide.MimicryOn();
                hit = false;
                Destroy(gameObject);
            }
            count++;
        }
    }
    public void SetTongue(float n)
    {
        tongueLength = n;
    }

}
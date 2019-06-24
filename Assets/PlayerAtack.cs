using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAtack : MonoBehaviour
{
    //挙動
    float tongueLength ;//舌を伸ばす最大距離を１秒で割った数を入れる
    public float tongue = 1.0f;       //スケールを１まで伸ばす
    public float extendTime = 1.0f;
    bool extend = false;
    GameObject player;
    PlayerMove playerscript;
    SetTomgue tonglescript;
    //下を伸ばす時間は大体一秒で伸ばしきる(ヨッシーならば)
    void Start()
    {
        player = GameObject.Find("player1");
        playerscript = player.GetComponent<PlayerMove>();
        tonglescript = player.GetComponent<SetTomgue>();
    }
    // Update is called once per frame
    void Update()
    {
        TongueExtend();
    }
    void TongueExtend()
    {
        //playerscript.Stop();
        playerscript.InputAbort();
        if(extend==false)
        {
            tongueLength += tongue / extendTime;
            transform.localScale = new Vector3(tongueLength, 1.0f, 1.0f);
        }
        else
        {
            tongueLength -= tongue / extendTime;
        }
        if (tongue == tongueLength)
        {
            extend = true;
        }
        if(tongueLength ==0.0f)
        {
            playerscript.inputPermit();
            tonglescript.ExtendEnd();
            Destroy(gameObject);
        }
    
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        //if(tongue == tongueLength)
        //{
        //}
        if(other.gameObject.tag == "enemy")
        {
            Destroy(other.gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hide : MonoBehaviour
{
    //SpriteRenderer spriteRenderer;
    public float stopperMin = 0.2f;         //この値を0にすると完全に透明になるまで色が変わる
    public float alphaAddSub = 0.01f;       //透明度の変化の仕方
    public float hideTime = 10.0f;          //隠れられる時間
    private float normal = 1.0f;             //色の状態  
    private float nowTime = 0.0f;           //擬態開始からの時間
    private float startTime = 0.0f;         //擬態開始時のみを取得する
    private float count = 0.0f;
    private float prevcount = 0.0f;
    private float stopperMax = 1.0f;        //透明度変化の最大この状態は完全に見えている状態
    private bool hit = true;                //当たり判定を変えるtrueで当たる
    private bool prevMimicryFlag = false;   //キーを押す前が擬態中かどうかを取る
    private bool mimicryFlag = false;       //現在擬態しているかどうかの状態trueが擬態中
    private bool canMimicry = true;         //擬態可能かどうかの状態trueが可
    private bool countrewriting = true;
    [SerializeField] GameObject Player;
    SetTomgue tomgleScript;
    PlayerMove player;
    [SerializeField] GameObject Player1;
    void Start()
    {
        Player = GameObject.Find("player");
        Player1 = GameObject.Find("player1");
        player = GetComponent<PlayerMove>();
        tomgleScript = GetComponent<SetTomgue>();
    }
    void Update()
    {
        if (canMimicry)
        {
            InputKey();
        }
        Imitation();
        AlphaControl();
        if(player.GetOnGround())
        {
            GetComponent<PolygonCollider2D>().enabled = hit;
            ChangeTransparency(normal,Player1);
        }
        else
        {
            Player.GetComponent<PolygonCollider2D>().enabled = hit;
            ChangeTransparency(normal,Player);
        }
    }
    //色を変える
    void ChangeTransparency(float alpha,GameObject name)
    {
        foreach (var item in name.GetComponentsInChildren<SpriteRenderer>())
        {
            item.color = new Color(1, 1, 1, alpha);
        }
    }
    //キー入力取得
    void InputKey()
    {
        if (Input.GetKeyDown(KeyCode.Space)||Input.GetButtonDown("joystick button 1"))
        {
            //ここに擬態開始の関数
            tomgleScript.AttackDisallowed();
            ChangeMimicryFlag();
            //ここで必ず読まないといけない
            if (!(prevMimicryFlag == true && mimicryFlag == false))
            {
                prevMimicryFlag = mimicryFlag;
            }
        }
    }
    //擬態フラグの変更
    void ChangeMimicryFlag()
    {
        if (prevMimicryFlag == false)
        {
            mimicryFlag = true;
        }
        else
        {
            mimicryFlag = false;
        }
    }
    //元の状態～擬態
    void ImitationStart()
    {
        if (normal > stopperMin)
        {
            normal -= alphaAddSub;
        }
        else
        {
            hit = false;
        }
    }
    //擬態～元の状態
    void ImitationRevert()
    {
        if (normal < stopperMax)
        {
            normal += alphaAddSub;
            hit = true;
            if (nowTime != 0 && countrewriting == true)
            {
                count = nowTime;
                countrewriting = false;
            }
            if (count != prevcount)
            {
                prevcount = count;
                nowTime = 0;
                startTime = 0;
            }
        }
        if (normal == stopperMax)
        {
            //ここでtrueじゃないといけない
            if(prevMimicryFlag==true)
            {
                tomgleScript.AttackPermit();
                prevMimicryFlag = false;
            }
        }
    }
    //擬態するか元に戻るか
    void Imitation()
    {
        if (startTime == 0.0f && hit == false)
        {
            ImitationStartTime();
            //ここに書き換え許可
            countrewriting = true;
        }
        if (startTime > 0 && hit == false)
        {
            GetTime();
            TimeCheck();
        }
        if (mimicryFlag == true)
        {
            ImitationStart();
        }
        else
        {
            ImitationRevert();
        }
    }
    //alpha値がこれ以上変化しないように調整
    void AlphaControl()
    {
        if (normal > stopperMax)
        {
            normal = stopperMax;
        }
        if (normal < stopperMin)
        {
            normal = stopperMin;
        }
    }
    //擬態が完了の時間を取得
    void ImitationStartTime()
    {
        startTime = Time.time;
    }
    //擬態開始からの経過時間を取得
    void GetTime()
    {
        nowTime = Time.time - startTime + count;
    }
    //経過時間が擬態できる時間を超えていないかを確認
    void TimeCheck()
    {
        if (nowTime > hideTime)
        {
            canMimicry = false;
            mimicryFlag = false;
            startTime = 0;
            count = nowTime;
            nowTime = 0;
        }
        if (nowTime >= 10 + count) 
        {
            mimicryFlag = false;
        }
    }
    public void MimicryOn()
    {
        canMimicry = true;
    }
    public void MimicryOff()
    {
        canMimicry = false;
    }
    public bool Mimicry()
    {
        return mimicryFlag;
    }
    public float GetCount()
    {
        return count;
    }
    public float Getnowtime()
    {
        return nowTime;
    }
}

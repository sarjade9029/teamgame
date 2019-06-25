using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hide : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public float stopperMin = 0.2f;         //この値を0にすると完全に透明になるまで色が変わる
    public float alphaAddSub = 0.01f;       //透明度の変化
    public float hideTime = 10.0f;          //隠れきるまでの時間
    public float normal = 1.0f;             //色の状態  
    private float nowTime = 0.0f;           //擬態開始からの時間
    private float resetTime = 0.0f;         //擬態開始時のみを取得する
    private float stopperMax = 1.0f;        //透明度変化の最大この状態は完全に見えている状態
    private bool hit = true;                //当たり判定を変えるtrueで当たる
    private bool prevMimicryFlag = false;   //キーを押す前が擬態中かどうかを取る
    private bool mimicryFlag = false;       //現在擬態しているかどうかの状態trueが擬態中
    private bool canMimicry = true;         //擬態可能かどうかの状態trueが可

    void Start()
    {
        this.spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        //InputKeyTypeB();
        if(canMimicry)
        {
            InputKey();
        }
        Imitation();
        AlphaControl();
        GetComponent<PolygonCollider2D>().enabled = hit;
        ChangeTransparency(normal);
    }
    //色を変える
    void ChangeTransparency(float alpha)
    {
        this.spriteRenderer.color = new Color(1, 1, 1, alpha);
    }
    //キー入力取得
    void InputKey()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //ここに擬態開始の関数
            ChangeMimicryFlag();
        }
        prevMimicryFlag = mimicryFlag;
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
            //ここに擬態から元に戻った関数を入れる
            hit = true;
            resetTime += GetTime();
        }
    }
    //別のキー入力
    void InputKeyTypeB()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            ImitationStart();
        }
        else
        {
            ImitationRevert();
        }
    }
    //擬態するか元に戻るか
    void Imitation()
    {
        if(resetTime==0.0f)
        {
            ImitationStartTime();
        }
        if(TimeCheck())
        {
            mimicryFlag = false;
            resetTime = 0.0f;
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
        nowTime = Time.time;
    }
    //擬態開始からの経過時間を取得
    float GetTime()
    {
        return Time.time - nowTime ;
    }
    //経過時間が擬態できる時間を超えていないかを確認
    bool TimeCheck()
    {
        return (GetTime() > hideTime);
    }
    public void MimicryOn()
    {
        canMimicry = true;
    }
    public void MimicryOff()
    {
        canMimicry = false;
    }

}

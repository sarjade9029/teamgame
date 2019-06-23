using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hide : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public float stopperMin = 0.2f;
    public float alphaAddSub = 0.01f;
    public float hideTime = 10.0f;
    private float nowTime = 0.0f;
    public float resetTime = 0.0f;
    public float normal = 1.0f;
    private bool hit = true;
    private float stopperMax = 1.0f;
    private bool prevMimicryFlag = false;
    private bool mimicryFlag = false;

    void Start()
    {
        //試験的なものこれは後hueで必ずボタンを押したときといオーバーレイう条件
        //ボタンを押すと元に戻る当たり判定を元に戻す処理を追加する
        this.spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        //InputKeyTypeB();
        InputKey();

        Imitation();
        
        AlphaControl();

        GetComponent<PolygonCollider2D>().enabled = hit;

        ChangeTransparency(normal); // 透明にする
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
        if (prevMimicryFlag == true)
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
}

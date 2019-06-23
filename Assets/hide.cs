using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hide : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public float invisible = 0.5f;
    public float normal = 1.0f;
    public bool hit = true;
    public float stopperMin = 0.2f;
    public float stopperMax = 1.0f;
    public float alphaChange = 0.01f;
    bool prevMimicryFlag = false;
    bool mimicryFlag = false;

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
    void StartImitation()
    {
        if (normal > stopperMin)
        {
            normal -= alphaChange;
        }
        else
        {
            hit = false;
        }

    }
    void RevertImitation()
    {
        if (normal < stopperMax)
        {
            normal += alphaChange;
            hit = true;
        }
    }
    void InputKeyTypeB()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            StartImitation();
        }
        else
        {
            RevertImitation();
        }
    }
    void Imitation()
    {
        if (mimicryFlag == true)
        {
            StartImitation();
        }
        if (mimicryFlag == false)
        {
            RevertImitation();
        }
    }
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
}

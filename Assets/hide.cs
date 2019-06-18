using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hide : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public float invisible = 0.5f;
    float normal = 1.0f;
    public bool hit = false;

    void Start()
    {
        //試験的なものこれは後で必ずボタンを押したときという条件
        //ボタンを押すと元に戻る当たり判定を元に戻す処理を追加する
        this.spriteRenderer = GetComponent<SpriteRenderer>();
        ChangeTransparency(normal); // 透明にする
        GetComponent<PolygonCollider2D>().enabled = hit;
    }
     void Update()
    {
        if(normal>0.2f)
        {
            normal -= 0.01f;
        }

        ChangeTransparency(normal); // 透明にする
    }
    void ChangeTransparency(float alpha)
    {
        this.spriteRenderer.color = new Color(1, 1, 1, alpha);
    }
}

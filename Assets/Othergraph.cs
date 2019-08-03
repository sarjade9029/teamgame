using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Othergraph : MonoBehaviour
{
    private float graphA = 1.0f;
    private float graphB = 0.0f;
    private float hidden = 0.0f;
    private float display = 1.0f;
    private bool hitA = true;
    private bool hitB = false;
    // Start is called before the first frame update
    SpriteRenderer spriteRenderer;
    GameObject other;
    SpriteRenderer otherSpriteRenderer;
    SpriteRenderer other2SpriteRenderer;
    void Start()
    {
        //べつの状態のプレイヤーとその子オブジェクトの取得
        other = GameObject.Find("player");
        otherSpriteRenderer = other.GetComponent<SpriteRenderer>();
        Transform other1 = other.transform.Find("otherCollider");
        Transform other2 = other.transform.Find("playerline");
        other2SpriteRenderer = other2.GetComponent<SpriteRenderer>();
        //プレイヤー本体の初期化
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = new Color(1, 1, 1, graphA);
        GetComponent<PolygonCollider2D>().enabled = hitA;
        //別の状態のプレイヤーの初期化
        otherSpriteRenderer.color = new Color(1, 1, 1, graphB);
        other.GetComponent<PolygonCollider2D>().enabled = hitB;
        //別の状態の子オブジェクトの初期化
        other2SpriteRenderer.color = new Color(1, 1, 1, graphB);
        other1.GetComponent<BoxCollider2D>().enabled = hitB;
    }

    // Update is called once per frame
    void Update()
    {
        //GetComponent<PolygonCollider2D>().enabled = hit;
    }
}

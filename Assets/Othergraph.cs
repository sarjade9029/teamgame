using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Othergraph : MonoBehaviour
{
    private float graphA = 1.0f;
    private float graphB = 0.0f;
    private bool hitA = true;
    private bool hitB = false;
    public bool prevGround = true;
    // Start is called before the first frame update
    SpriteRenderer spriteRenderer;
    GameObject other;
    SpriteRenderer otherSpriteRenderer;
    SpriteRenderer other2SpriteRenderer;
    SpriteRenderer LinespriteRenderer;
    PlayerMove playerMove;
    Transform other1;
    Transform other2;
    Transform Line;
    Transform HitGraound;
    Transform HitOther;
    void Start()
    {
        //べつの状態のプレイヤーとその子オブジェクトの取得
        other = GameObject.Find("player");
        playerMove = GetComponent<PlayerMove>();
        otherSpriteRenderer = other.GetComponent<SpriteRenderer>();
        other1 = other.transform.Find("otherCollider");
        other2 = other.transform.Find("playerline");
        other2SpriteRenderer = other2.GetComponent<SpriteRenderer>();
        //プレイヤー本体の初期化
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = new Color(1, 1, 1, graphA);
        GetComponent<PolygonCollider2D>().enabled = hitA;
        //プレイヤーの子オブジェクトの初期化
        //groundhit
        HitGraound = transform.Find("CheckHitGround");
        HitGraound.GetComponent<BoxCollider2D>().enabled = hitA;
        //othercoll
        Line = transform.Find("playerLine");
        LinespriteRenderer = Line.GetComponent<SpriteRenderer>(); 
        LinespriteRenderer.color = new Color(1, 1, 1, graphA);
        //othercollider
        HitOther = transform.Find("othercollider");
        HitOther.GetComponent<BoxCollider2D>().enabled = hitA;
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
        if(playerMove.GetOnGround()==true)
        {
            if (prevGround == false) 
            {
                //地面についているとき
                //プレイヤーの表示
                spriteRenderer.color = new Color(1, 1, 1, graphA);
                GetComponent<PolygonCollider2D>().enabled = hitA;
                //別の状態のプレイヤーの透明化
                otherSpriteRenderer.color = new Color(1, 1, 1, graphB);
                other.GetComponent<PolygonCollider2D>().enabled = hitB;
                //別の状態の子オブジェクトの透明化
                other2SpriteRenderer.color = new Color(1, 1, 1, graphB);
                other1.GetComponent<BoxCollider2D>().enabled = hitB;
                //プレイヤーの子オブジェクトの表示
                //groundhit
                HitGraound.GetComponent<BoxCollider2D>().enabled = hitA;
                //othercoll
                LinespriteRenderer = Line.GetComponent<SpriteRenderer>();
                LinespriteRenderer.color = new Color(1, 1, 1, graphA);
                HitOther.GetComponent<BoxCollider2D>().enabled = hitA;
                prevGround = true;
            }
        }
        else
        {
            if (prevGround == true) 
            {
                //宙に浮いているとき
                //プレイヤーの透明化
                spriteRenderer.color = new Color(1, 1, 1, graphB);
                GetComponent<PolygonCollider2D>().enabled = hitB;
                //別の状態のプレイヤーの表示
                otherSpriteRenderer.color = new Color(1, 1, 1, graphA);
                other.GetComponent<PolygonCollider2D>().enabled = hitA;
                //別の状態の子オブジェクトの表示
                other2SpriteRenderer.color = new Color(1, 1, 1, graphA);
                other1.GetComponent<BoxCollider2D>().enabled = hitA;
                //プレイヤーの子オブジェクトの透明化
                //groundhit
                HitGraound.GetComponent<BoxCollider2D>().enabled = hitB;
                //othercoll
                LinespriteRenderer.color = new Color(1, 1, 1, graphB);
                HitOther.GetComponent<BoxCollider2D>().enabled = hitB;
                prevGround = false;
            }
        }
    }
}

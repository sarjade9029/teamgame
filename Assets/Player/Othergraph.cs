using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Othergraph : MonoBehaviour
{
    private float graphA = 1.0f;
    private float graphB = 0.0f;
    private bool hitA = true;
    private bool hitB = false;
    private bool prevGround = true;
    PlayerMove playerMove;
    SpriteRenderer regleft;
    SpriteRenderer regright;
    SpriteRenderer spriteRenderer;
    SpriteRenderer LinespriteRenderer;
    SpriteRenderer otherSpriteRenderer;
    SpriteRenderer other2SpriteRenderer;
    Transform WallPlayerLine;
    [SerializeField] GameObject WallPlayer;
    [SerializeField] Transform Line;
    [SerializeField] Transform leftreg;
    [SerializeField] Transform rightreg;
    [SerializeField] Transform PlayerHitOther;
    [SerializeField] Transform PlayerHitGraound;
    void Start()
    {
        //べつの状態のプレイヤーとその子オブジェクトの取得
        playerMove = GetComponent<PlayerMove>();
        otherSpriteRenderer = WallPlayer.GetComponent<SpriteRenderer>();
        WallPlayerLine = WallPlayer.transform.Find("playerline");
        other2SpriteRenderer = WallPlayerLine.GetComponent<SpriteRenderer>();
        //プレイヤー本体の初期化
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = new Color(1, 1, 1, graphA);
        GetComponent<PolygonCollider2D>().enabled = hitA;
        //プレイヤーの子オブジェクトの初期化
        //groundhit
        PlayerHitGraound.GetComponent<BoxCollider2D>().enabled = hitA;
        //othercoll
        LinespriteRenderer = Line.GetComponent<SpriteRenderer>(); 
        LinespriteRenderer.color = new Color(1, 1, 1, graphA);
        //othercollider
        PlayerHitOther.GetComponent<BoxCollider2D>().enabled = hitA;
        //rightreg
        regright = rightreg.GetComponent<SpriteRenderer>();
        regright.color = new Color(1, 1, 1, graphA);
        //leftreg
        regleft = leftreg.GetComponent<SpriteRenderer>();
        regleft.color = new Color(1, 1, 1, graphA);
        //別の状態のプレイヤーの初期化
        otherSpriteRenderer.color = new Color(1, 1, 1, graphB);
        WallPlayer.GetComponent<PolygonCollider2D>().enabled = hitB;
        //別の状態の子オブジェクトの初期化
        other2SpriteRenderer.color = new Color(1, 1, 1, graphB);
    }
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
                regright.color = new Color(1, 1, 1, graphA);    
                regleft.color = new Color(1, 1, 1, graphA);
                //別の状態のプレイヤーの透明化
                otherSpriteRenderer.color = new Color(1, 1, 1, graphB);
                WallPlayer.GetComponent<PolygonCollider2D>().enabled = hitB;
                //別の状態の子オブジェクトの透明化
                other2SpriteRenderer.color = new Color(1, 1, 1, graphB);
                //othercoll
                LinespriteRenderer = Line.GetComponent<SpriteRenderer>();
                LinespriteRenderer.color = new Color(1, 1, 1, graphA);
                PlayerHitOther.GetComponent<BoxCollider2D>().transform.localScale = new Vector3(5.3f, 2.4f, 1);
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
                regright.color = new Color(1, 1, 1, graphB);
                regleft.color = new Color(1, 1, 1, graphB);
                //別の状態のプレイヤーの表示
                otherSpriteRenderer.color = new Color(1, 1, 1, graphA);
                WallPlayer.GetComponent<PolygonCollider2D>().enabled = hitA;
                //別の状態の子オブジェクトの表示
                other2SpriteRenderer.color = new Color(1, 1, 1, graphA);
                //othercoll
                LinespriteRenderer.color = new Color(1, 1, 1, graphB);
                PlayerHitOther.GetComponent<BoxCollider2D>().transform.localScale = new Vector3(2.2f, 2.5f, 1);
                prevGround = false;
            }
        }
    }
}

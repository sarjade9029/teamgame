using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour
{
    float startTime;
    public float xSpeed = 5.0f;
    public int dmg = 1;
    GameObject Player;
    GameObject Player1;
    PlayerMove Playermove;
    private float playerposy;
    public float deletetime = 2.0f;
    // Use this for initialization
    void Start()
    {
        Player = GameObject.Find("player1");
        Playermove = Player.GetComponent<PlayerMove>();
        playerposy = Player.transform.localPosition.y;
        startTime = Time.time;
        Player1 = GameObject.Find("player");
    }
    // Update is called once per frame
    void Update()
    {
        Rigidbody2D myRigid = GetComponent<Rigidbody2D>();
        // 現在時刻から開始時刻を引くと、開始から経過時間がとれる
        // それが5秒より大きいとき自殺する
        if (Time.time - startTime > deletetime)
        {
            if (deletetime > 0)
            {
                Destroy(gameObject);
            }
        }
        // たまが反対を向いている（スケールがマイナス）なら反対に進ませる
        if (transform.localScale.x < 0)
        {
            //右向き
            if (playerposy >= -5 && playerposy <= -2)
            {
                myRigid.velocity = transform.right * xSpeed;
                transform.rotation = Quaternion.AngleAxis(0, new Vector3(0, 0, 1));
            }
            if (playerposy > -2 && playerposy < 2)
            {
                myRigid.velocity = new Vector2(xSpeed * 0.7f, xSpeed * 0.7f);
                transform.rotation = Quaternion.AngleAxis(45, new Vector3(0, 0, 1));
            }
            if (playerposy >= 2 && playerposy <= 6)
            {
                myRigid.velocity = transform.up * xSpeed;
                transform.rotation = Quaternion.AngleAxis(90, new Vector3(0, 0, 1));
            }
        }
        else
        {
            //左向き
            if (playerposy >= -5 && playerposy <= -2)
            {
                myRigid.velocity = -transform.right * xSpeed;
                transform.rotation = Quaternion.AngleAxis(0, new Vector3(0, 0, 1));
            }
            if (playerposy > -2 && playerposy < 2)
            {
                myRigid.velocity = new Vector2(-xSpeed * 0.7f, xSpeed * 0.7f);
                transform.rotation = Quaternion.AngleAxis(-45, new Vector3(0, 0, 1));
            }
            if (playerposy >= 2 && playerposy <= 6)
            {
                myRigid.velocity = transform.up * xSpeed;
                transform.rotation = Quaternion.AngleAxis(-90, new Vector3(0, 0, 1));
            }
        }
    }
    //以下不変
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            //使うステを取る
            if(Playermove.GetOnGround()==true)
            {
                PlayerMove player = other.gameObject.GetComponent<PlayerMove>();
                //体力減らす
                player.sleepiness -= dmg;
                if (player.sleepiness <= 0)
                {
                    Destroy(other.gameObject);
                    Destroy(Player1.gameObject);
                }
                if (this.tag != "girochin")
                {
                    Destroy(gameObject);
                }
            }
            else
            {
                //体力減らす
                Playermove.sleepiness -= dmg;
                if (Playermove.sleepiness <= 0)
                {
                    Destroy(other.gameObject);
                    Destroy(Player.gameObject);
                }
                if (this.tag != "girochin")
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}
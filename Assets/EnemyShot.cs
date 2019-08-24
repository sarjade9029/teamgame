using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour
{
    float startTime;
    public float xSpeed = 5.0f;
    public int dmg = 1;
    GameObject Player;
    PlayerMove Playermove;
    // Use this for initialization
    void Start()
    {
        Player = GameObject.Find("player1");
        Playermove = Player.GetComponent<PlayerMove>();
        startTime = Time.time;
    }
    // Update is called once per frame
    void Update()
    {
        Rigidbody2D myRigid = GetComponent<Rigidbody2D>();
        // 現在時刻から開始時刻を引くと、開始から経過時間がとれる
        // それが5秒より大きいとき自殺する
        if (Time.time - startTime > 5.0f)
        {
            Destroy(gameObject);
        }
        // たまが反対を向いている（スケールがマイナス）なら反対に進ませる
        if (transform.localScale.x < 0)
        {
            myRigid.velocity = transform.right * xSpeed;
        }
        else
        {
            myRigid.velocity = -transform.right * xSpeed;
        }
    }
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
                if (player.sleepiness == 0)
                {
                    Destroy(other.gameObject);
                }
                Destroy(gameObject);
            }
            else
            {
                //体力減らす
                Playermove.sleepiness -= dmg;
                if (Playermove.sleepiness == 0)
                {
                    Destroy(other.gameObject);
                }
                Destroy(gameObject);
            }
            ////体力減らす
            //player.sleepiness++;
            //if (player.sleepiness >= 10)
            //{
            //    Destroy(other.gameObject);
            //}
            //Destroy(gameObject);
        }
    }
}

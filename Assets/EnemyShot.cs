using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour
{
    public Rigidbody2D myRigid;

    float startTime;
    public float xSpeed = 0.5f;

    // Use this for initialization
    void Start()
    {
        startTime = Time.time;
    }
    // Update is called once per frame
    void Update()
    {
        // 現在時刻から開始時刻を引くと、開始から経過時間がとれる
        // それが３秒より大きいとき自殺する
        if (Time.time - startTime > 5.0f)
        {
            Destroy(gameObject);
        }
        // たまが反対を向いている（スケールがマイナス）なら反対に進ませる
        if (transform.localScale.x < 0)
        {
            myRigid.velocity = -transform.right * xSpeed;
        }
        else
        {
            myRigid.velocity = transform.right * xSpeed;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            //使うステを取る
            PlayerMove player = other.gameObject.GetComponent<PlayerMove>();
            //体力減らす
            player.sleepiness++;
            if (player.sleepiness >= 10)
            {
                Destroy(other.gameObject);
            }
            Destroy(gameObject);
        }
    }
}

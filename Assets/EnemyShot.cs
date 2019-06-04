using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour
{
    float startTime;
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
            //Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        //弾に入れるスクリプト弾を自動で殺す
        //Debug.Log(other.gameObject + "当たり！");
        if (other.gameObject.tag == "player")
        {
            //使うステを取る
            Player player = other.gameObject.GetComponent<Player>();
            //体力減らす
            player.sleepiness++;
            if (player.sleepiness <= 10)
            {
                Destroy(other.gameObject);
            }
            Destroy(gameObject);
        }
    }
}

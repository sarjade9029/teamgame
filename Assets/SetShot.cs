using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetShot : MonoBehaviour
{
    //public GameObject shotObject;
    //弾の目標と弾の形を指定する
    //public GameObject shotPosObject;
    //プレイヤーオブジェクト
    public GameObject playerPos;
    //弾のプレハブオブジェクト
    public GameObject shotObject;

    public GameObject enemyPos;
    private float currentTime = 0;
    //public float life_time = 1.5f;
    void Start()
    {
       
    }
    void Update()
    {
        currentTime++;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player" && currentTime == 60)
        {
            currentTime = 0;
            //敵の座標を変数posに保存
            var pos = enemyPos.transform.position;

            //ゲームオブジェクトの格納
            GameObject newShot = GameObject.Instantiate(shotObject);
            //オブジェクトの位置を敵と同じにする
            newShot.transform.position = enemyPos.transform.position;

            //弾のプレハブを作成
            //var t = Instantiate(tama) as GameObject;
            //弾のプレハブの位置を敵の位置にする
            //t.transform.position = pos;

            //敵からプレイヤーに向かうベクトルをつくる
            //プレイヤーの位置から敵の位置（弾の位置）を引く
            Vector2 vec = playerPos.transform.position - pos;

            //弾のRigidBody2Dコンポネントのvelocityに先程求めたベクトルを入れて力を加える
            newShot.GetComponent<Rigidbody2D>().velocity = vec;


        }
    }
}

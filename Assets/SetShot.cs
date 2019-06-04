using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shot : MonoBehaviour
{
    //public GameObject shotObject;
    //弾の目標と弾の形を指定する
    //public GameObject shotPosObject;
    //プレイヤーオブジェクト
    public GameObject player;
    //弾のプレハブオブジェクト
    public GameObject tama;

    public GameObject enemy;
    private float currentTime = 0;
    //public float life_time = 1.5f;
    private SpriteRenderer sr = null;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    void Update()
    {


    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "player" && currentTime == 60)
        {
            currentTime = 0;
            //敵の座標を変数posに保存
            var pos = enemy.transform.position;
            //弾のプレハブを作成
            var t = Instantiate(tama) as GameObject;
            //弾のプレハブの位置を敵の位置にする
            t.transform.position = pos;
            //敵からプレイヤーに向かうベクトルをつくる
            //プレイヤーの位置から敵の位置（弾の位置）を引く
            Vector2 vec = player.transform.position - pos;
            //弾のRigidBody2Dコンポネントのvelocityに先程求めたベクトルを入れて力を加える
            t.GetComponent<Rigidbody2D>().velocity = vec;

        }
    }
}

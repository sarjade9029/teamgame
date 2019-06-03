using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour
{
    
    public GameObject shotObject;

    public GameObject shotPosObject;
    public float speed = 0.1f;
    public float life_time = 1.5f;
    float time = 0f;
    void Start()
    {
        time = 0;
    }
    // Update is called once per frame
    void Update()
    {

        //ショットのゲームオブジェクトをコピーする
        //コピーした物をnewshotに入れる
        GameObject newShot = GameObject.Instantiate(shotObject);

        //mewshotの位置をプレイヤーと同じにする
        newShot.transform.position = shotPosObject.transform.position;

        //向きを同じにする
        newShot.transform.rotation = gameObject.transform.rotation;

        time += Time.deltaTime;
        if (time > life_time)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        //Debug.Log(other.gameObject + "当たり！");
        if (other.gameObject.tag == "player")
        {
            //使うステを取る
            Player player = other.gameObject.GetComponent<Player>();
            //体力減らす
            player.sleepiness = player.sleepiness + 1;
            if (player.sleepiness <= 10)
            {
                Destroy(other.gameObject);
            }
            Destroy(gameObject);
        }
    }
}

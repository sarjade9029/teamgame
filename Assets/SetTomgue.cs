using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTomgue : MonoBehaviour
{
    //生成
    GameObject player;
    PlayerMove playerscript;
    float tongueLength;//舌を伸ばす最大距離を１秒で割った数を入れる
    public float tongue = 1.0f;       //スケールを１まで伸ばす
    private bool hit = false;
    private bool extend = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player1");
        playerscript = player.GetComponent<PlayerMove>();
        extend = true;
        hit = true;
    }

    // Update is called once per frame
    void Update()
    {
        TongueExtend();
    }
    void TongueExtend()
    {
        if (extend == true)
        {
            GetComponent<PolygonCollider2D>().enabled = hit;
            tongueLength += tongue / 1.0f;
            transform.localScale = new Vector3(tongueLength, 1.0f, 1.0f);
            if (tongue == tongueLength)
            {
                hit = false;
            }
        }
        else
        {
            GetComponent<PolygonCollider2D>().enabled = hit;
        }
    }
}

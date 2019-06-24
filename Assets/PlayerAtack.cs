using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAtack : MonoBehaviour
{
    //挙動
    float tongueLength ;//舌を伸ばす最大距離を１秒で割った数を入れる
    public float tongue = 1.0f;       //スケールを１まで伸ばす
    private bool hit = false;
    private bool extend = false;
    public GameObject tomgue;
    //下を伸ばす時間は大体一秒で伸ばしきる(ヨッシーならば)
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        KeyInput();
        TongueExtend();
    }
    void KeyInput()
    {
        if (Input.GetKey(KeyCode.E))
        {
            extend = true;
            hit = true;
        }
    }
    void TongueExtend()
    {
        if (extend == true)
        {
            PlayerMove player = GetComponent<PlayerMove>();
            player.Stop();
            GetComponent<PolygonCollider2D>().enabled = hit;
            tongueLength += tongue / 1.0f;
            transform.localScale = new Vector3(tongueLength, 1.0f, 1.0f);
            if (tongue == tongueLength)
            {
                tongueLength -= tongue / 1.0f;
                if(tongueLength ==0.0f)
                {
                    hit = false;
                    Destroy(gameObject);
                }
            }
        }
        else
        {
            GetComponent<PolygonCollider2D>().enabled = hit;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        //if(tongue == tongueLength)
        //{
        //}
            Destroy(other.gameObject);
    }
}

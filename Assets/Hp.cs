using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hp : MonoBehaviour

{

    Slider hpSlider;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player1");
        hpSlider = GetComponent<Slider>();

        float maxHp = 200f;
        float nowHp = 200f;


        //スライダーの最大値の設定
        hpSlider.maxValue = maxHp;

        //スライダーの現在値の設定
        hpSlider.value = nowHp;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            hpSlider.value -= 10.0f;
        }
        
    }
}

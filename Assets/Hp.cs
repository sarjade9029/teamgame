using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hp : MonoBehaviour

{

    Slider hpSlider;
    GameObject player;
    Hide hide;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player1");
        hide = player.GetComponent<Hide>();
        hpSlider = GetComponent<Slider>();


        //スライダーの最大値の設定
        hpSlider.maxValue = hide.hideTime;

    }

    // Update is called once per frame
    void Update()
    {
        if(hide.mimicry()==true)
        {
            if (hide.Getnowtime() != 0)
            {
                //スライダーの現在値の設定
                hpSlider.value = hide.hideTime - hide.Getnowtime();
            }
        }
        else
        {
            hpSlider.value = hide.hideTime - hide.GetCount();
        }

    }
}

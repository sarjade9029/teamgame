using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hp : MonoBehaviour
{
    Hide hide;
    Slider hpSlider;
    [SerializeField] GameObject player;
    void Start()
    {
        hide = player.GetComponent<Hide>();
        hpSlider = GetComponent<Slider>();
        hpSlider.maxValue = hide.hideTime;
    }
    void Update()
    {
        if(hide.Mimicry()==true)
        {
            if (hide.Getnowtime() != 0)
            {
                hpSlider.value = hide.hideTime - hide.Getnowtime();
            }
        }
        else
        {
            hpSlider.value = hide.hideTime - hide.GetCount();
        }
    }
}

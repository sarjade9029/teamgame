//おそらく未使用
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hpui : MonoBehaviour
{
    public bool roop;
    public float countTime = 5.0f;
    public float amountcount;
    public Image UIobj;
    void Update()
    {
        amountcount = UIobj.fillAmount;
        if (roop)
        {
            UIobj.fillAmount -= 1.0f / countTime * Time.deltaTime;
        }  else if (!roop) {
            UIobj.fillAmount += 1.0f / countTime * Time.deltaTime;
        }
        if (UIobj.fillAmount == 0 ||UIobj.fillAmount == 1)
        {
            UIobj.fillClockwise = !UIobj.fillClockwise;
            roop = !roop;
        }
    }
}

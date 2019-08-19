using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class Hpui : MonoBehaviour
{
    public Image UIobj;  
    public bool roop;
    public float countTime = 5.0f;
    public float amountcount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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

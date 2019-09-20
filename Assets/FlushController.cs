//未使用
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlushController : MonoBehaviour
{
    [SerializeField] float nowtime = 0;
    public bool flag = true;
    public float timeleft;
    Image img;
    void Start()
    {
        timeleft = 0;
        img = GetComponent<Image>();
        img.color = Color.clear;
    }
    void Update()
    {
        nowtime++;
        if (((System.DateTime.Now.Second - timeleft) % 2) == 0)
        {
            flag = true;
        }
        if (flag == true)
        {
            this.img.color = new Color(0.5f, 0f, 0f, 0.5f);
            flag = false;
        }
        else
        {
            this.img.color = Color.Lerp(this.img.color, Color.clear, Time.deltaTime);
        }
    }
}

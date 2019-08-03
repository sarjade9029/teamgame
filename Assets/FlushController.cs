using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlushController : MonoBehaviour
{
    Image img;
    public bool flag = true;//boolで管理
    public float timeleft;
    float nowtime = 0;
    // Start is called before the first frame update
    void Start()
    {
        timeleft = 0;//スクリプト開始時間を取得
        img = GetComponent<Image>();
        img.color = Color.clear;
        
    }
    // Update is called once per frame
 
    void Update()
    {
        //二秒ごとにon/off
        nowtime++;
        //だいたい2秒ごとに処理を行う
        if (((System.DateTime.Now.Second - timeleft)% 2) == 0) 
        {
            flag = true;
        }

 

        if (flag==true)
        {
            this.img.color = new Color(0.5f, 0f, 0f, 0.5f );
            flag = false;
            //徐々に赤くする
        }
        else
        {
            this.img.color = Color.Lerp(this.img.color, Color.clear, Time.deltaTime);
            //元に戻す
        }
        
    }
}

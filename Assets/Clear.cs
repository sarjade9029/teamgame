using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clear  : MonoBehaviour
{
    public float time = 0;                  //ゲーム開始してからの時間
    public GameObject score_object = null;  //Textオブジェクト
    void Start()
    {
        float num1 = Mathf.Floor(Time.time);
    }
    void Update()
    {
        Text score_text = score_object.GetComponent<Text>();
        score_text.text = "タイム:" + (Time.time - time);
        score_object.GetComponent<Text>().text = Time.time.ToString("F2");
    }
}

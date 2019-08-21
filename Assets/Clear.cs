using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class Clear  : MonoBehaviour
{

    public GameObject score_object = null; // Textオブジェクト
    // Start is called before the first frame update
    void Start()
    {
        float num1 = Mathf.Floor(Time.time);  //切り捨て
    }

    // Update is called once per frame
    void Update()
    {
        Text score_text = score_object.GetComponent<Text>();
        score_text.text = "タイム:" + Time.time;
        score_object.GetComponent<Text>().text = Time.time.ToString("F2");//小数2桁にして表示
    }
}

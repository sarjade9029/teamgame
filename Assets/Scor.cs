using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scor : MonoBehaviour
{

    public GameObject score_object = null; // Textオブジェクト
    public int score_num = 0; // スコア変数


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Text score_text = score_object.GetComponent<Text>();

        score_text.text = "スコア:" + score_num;


        score_num += 0;
    }
}

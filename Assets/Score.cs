using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    public GameObject score_object = null; // Textオブジェクト
    private int score_num = 0; // スコア変数
    Text score_text;
    GameObject player;
    PlayerMove playerscore;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player1");
        playerscore = player.GetComponent<PlayerMove>();
        score_text = score_object.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        score_num = playerscore.GetScore();
        score_text.text = "スコア:"+ score_num;
    }
}

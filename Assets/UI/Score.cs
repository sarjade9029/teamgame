using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    public GameObject cointext;
    public GameObject score_object = null; // Textオブジェクト
    private int coin_num = 0;
    private int score_num = 0; // スコア変数
    Text coin_text;
    Text score_text;
    PlayerMove playerscore;
    [SerializeField] GameObject player;
    void Start()
    {
        playerscore = player.GetComponent<PlayerMove>();
        score_text = score_object.GetComponent<Text>();
        coin_text = cointext.GetComponent<Text>();
    }
    void Update()
    {
        score_num = playerscore.GetScore();
        score_text.text = "スコア:"+ score_num;
        coin_num = playerscore.GetCoin();
        coin_text.text = "コイン" + coin_num + "/40";
    }
}

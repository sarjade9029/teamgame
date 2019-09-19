using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    public GameObject score_object = null; // Textオブジェクト
    private int score_num = 0; // スコア変数
    private int coin_num = 0;
    public GameObject cointext;
    Text coin_text;
    Text score_text;
    [SerializeField] GameObject player;
    PlayerMove playerscore;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player1");
        playerscore = player.GetComponent<PlayerMove>();
        score_text = score_object.GetComponent<Text>();
        coin_text = cointext.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        score_num = playerscore.GetScore();
        score_text.text = "スコア:"+ score_num;
        coin_num = playerscore.GetCoin();
        coin_text.text = "コイン" + coin_num + "/40";
    }
}

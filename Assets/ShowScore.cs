using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class ShowScore : MonoBehaviour
{
    public GameObject score_object = null;//Textオブジェクト
    GameObject Player;
    PlayerMove Playermove;
    private int score;

    // Start is called before the first frame update
    void Start()
    {
        //GameObject.Find("player1");
        Playermove = Player.GetComponent<PlayerMove>();
        score = Playermove.GetScore();
    }

    // Update is called once per frame
    void Update()
    {
        score = Playermove.GetScore();

        Text score_text = score_object.GetComponent<Text>();

        score_text.text = "スコア：" + score;

        score += 0;
        
    }
}

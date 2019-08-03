using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class TimeManager : MonoBehaviour

{
    public Text scoreText;//スコアのUI
    private int score;//スコア
    private Text scoreLabel;

    
   
    // Start is called before the first frame update
    void Start()
    {

        score = 0;
        
        

        scoreLabel = GameObject.Find("ScoreLabel").GetComponent<Text>();
        scoreLabel.text = "SCPRE:" + score;

    }
 public void AddScore(int amount)
    {
        score += amount;
        scoreLabel.text = "SCORE:" + score;

    }
    //玉がほかのオブジェクトにぶつかったときによびだされる
    private void OnTriggerEnter(Collider other)
    {
        //
        if (other.gameObject.CompareTag("Pick Up"))
        {
            //スコアを加算します
            score = score + 1;

            //
            

        }
    }



    // Update is called once per frame
    void Update()
    {
 

 


  

    }
}

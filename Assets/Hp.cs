using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;




public class Hp : MonoBehaviour
{
   int max_life_limit = 10;
   float fillProp = 0.75f;
    Image Frame;
    Image Hpgauge;
    Image GageTerminal;
    PlayerMove playermove;
        GameObject player;
    

    // Start is called before the first frame update
    void Start()
    {
        GageTerminal = transform.Find("GageTerminal").GetComponent<Image>();
        player =GameObject.Find("player1");
        playermove = player.GetComponent<PlayerMove>(); 
         Frame = transform.Find("Frame").GetComponent<Image>();
       Hpgauge  = transform.Find("Hpgauge").GetComponent<Image>();
        
    }
    void Update()
    {
        
        
       

        Frame.fillAmount = (10 / max_life_limit) * fillProp;
        Hpgauge.fillAmount = (playermove.sleepiness / 10) * Frame.fillAmount;//いじる

        GageTerminal.rectTransform.rotation = Quaternion.Euler(new Vector3(0, 0, -360f * Frame.fillAmount));

        


    }

    
    

}
    


    // Update is called once per frame
    //void Update()
   // {
        
   // }


﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObstruct : MonoBehaviour
{
    GameObject Player;
    SetTomgue tomgleScript;
    int time = 0;
    bool defeatobstruct;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("player1");
        tomgleScript = Player.GetComponent<SetTomgue>();
    }

    // Update is called once per frame
    void Update()
    {
        if (defeatobstruct == true)
        {
            if(time<=90)
            {
                transform.Rotate(new Vector3(0, 0, 1));
            }
            else
            {
                defeatobstruct = false;
            }
            time++;
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag=="player")
        {
            tomgleScript.AttackDisallowed();
            if (Input.GetKeyDown(KeyCode.E))
            {
                defeatobstruct = true;   
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "player")
        {
            if(defeatobstruct == false)
            {
                tomgleScript.AttackPermit();
            }
        }
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Stage4toGameClear : MonoBehaviour
{
    GameObject player;
    PlayerMove playerMove;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player");
        playerMove = player.GetComponent<PlayerMove>();
    }
    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            //stage4から
            if (Input.GetButton("joystick button 3") || Input.GetKey(KeyCode.Q))
            {
                if (playerMove.GetKeyState() == true)
                {
                    SceneManager.LoadScene("GameClear");
                }
            }
        }
    }
}

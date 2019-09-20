﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Stage2toStage3 : MonoBehaviour
{
    PlayerMove playerMove;
    [SerializeField] GameObject player;
    void Start()
    {
        playerMove = player.GetComponent<PlayerMove>();
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            //stage2から
            if (Input.GetButton("joystick button 3") || Input.GetKey(KeyCode.Q))
            {
                if (playerMove.GetKeyState() == true)
                {
                    SceneManager.LoadScene("stage3");
                }
            }
        }
    }
}

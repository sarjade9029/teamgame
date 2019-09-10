using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Stage1toStage2 : MonoBehaviour
{
    GameObject player;
    PlayerMove playerMove;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player1");
        playerMove = player.GetComponent<PlayerMove>();
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            //stage1から
            if (Input.GetButton("joystick button 3") || Input.GetKey(KeyCode.Q))
            {
                if (playerMove.GetKeyState() == true)
                {
                    SceneManager.LoadScene("stage2");
                }
            }
        }
    }
}

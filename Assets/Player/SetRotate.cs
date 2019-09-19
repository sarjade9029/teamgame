using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetRotate : MonoBehaviour
{
    public GameObject wallplayer;
    public GameObject collder;
    GameObject player;
    PlayerMove playerMove;
    // Update is called once per frame
    void Start()
    {
        player = GameObject.Find("player1");
        playerMove = player.GetComponent<PlayerMove>();
    }
    void Update()
    {
        if (playerMove.GetOnGround() == false)
        {
            collder.transform.rotation = wallplayer.transform.rotation;
        }
        else
        {
            collder.transform.rotation = player.transform.rotation;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setpos : MonoBehaviour
{
    public PlayerMove playerMove;
    public GameObject wallplayer;
    public Animator anim;
    // Update is called once per frame
    void Update()
    {
        wallplayer.transform.position = playerMove.transform.position;
        anim.SetBool("Walk", playerMove.movement);
    }
}

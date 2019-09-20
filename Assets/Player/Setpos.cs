using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setpos : MonoBehaviour
{
    public Animator anim;
    public PlayerMove playerMove;
    public GameObject wallplayer;
    void Update()
    {
        wallplayer.transform.position = playerMove.transform.position;
        anim.SetBool("Walk", playerMove.movement);
    }
}

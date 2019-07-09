using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setpos : MonoBehaviour
{
    public GameObject player;
    public GameObject wallplayer;
    // Update is called once per frame
    void Update()
    {
        wallplayer.transform.position = player.transform.position;
    }
}

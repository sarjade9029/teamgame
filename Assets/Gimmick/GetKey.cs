﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetKey : MonoBehaviour
{
    PlayerMove playermovescript;
    [SerializeField] GameObject Player;
    void Start()
    {
        playermovescript = Player.GetComponent<PlayerMove>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            playermovescript.GetKey();
            Destroy(this.gameObject);
        }
    }
}

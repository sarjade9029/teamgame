//未使用
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPoint : MonoBehaviour
{
    private int time = 0;
    private int cooltime = 300;
    PlayerMove playerm;
    [SerializeField] GameObject player;
    void Start()
    {
        playerm = player.GetComponent<PlayerMove>();
    }
    void Update()
    {
        time++;
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (playerm.sleepiness < 10)
            {
                if (time >= cooltime)
                {
                    if(playerm.sleepiness<9)
                    {
                        playerm.sleepiness += 2;
                    }
                    else
                    {
                        playerm.sleepiness++;
                    }
                    time = 0;
                }
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour
{
    public int StopTime = 2;
    private int count = 0;
    private bool fall = false;
    PlayerMove playermove;
    [SerializeField] GameObject player;
    void Start()
    {
        playermove = player.GetComponent<PlayerMove>();
    }
    void Update()
    {
        if (fall == true)
        {
            if (playermove.GetOnGround() == false)
            {
                playermove.InputAbort();
                player.transform.position += new Vector3(0.0f, -playermove.posSpeed, 0.0f);
            }
            else
            {
                count++;
                if (StopTime * 60 == count)
                {
                    playermove.InputPermit();
                    count = 0;
                    fall = false;
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            fall = true;
        }
    }
}

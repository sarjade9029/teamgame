using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour
{
    GameObject player;
    PlayerMove playermove;
    private bool fall = false;
    public int count = 5;
    private int StopTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player1");
        playermove = player.GetComponent<PlayerMove>();
    }
    // Update is called once per frame
    void Update()
    {
        if (fall == true)
        {
            if (playermove.GetOnGround() == false)
            {
                playermove.inputPermit();
                player.transform.position += new Vector3(0.0f, -playermove.posSpeed, 0.0f);
            }
            else
            {
                if (StopTime == count)
                {
                    playermove.InputAbort();

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

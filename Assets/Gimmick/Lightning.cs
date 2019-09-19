using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour
{
    [SerializeField] GameObject player;
    PlayerMove playermove;
    private bool fall = false;
    private int count = 0;
    public int StopTime = 2;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player1");
        playermove = player.GetComponent<PlayerMove>();
    }
    // Update is called once per frame
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

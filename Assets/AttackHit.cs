
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHit : MonoBehaviour
{
    GameObject Player;
    PlayerMove playermovescript;
    void Start()
    {
        Player = GameObject.Find("player1");
        playermovescript = Player.GetComponent<PlayerMove>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "enemy")
        {
            if (other.gameObject.transform.localScale.x != Player.transform.localScale.x)
            {
                Player.GetComponent<Animator>().SetTrigger("Eat");
                playermovescript.AddScore(100);
                Destroy(other.gameObject);
                Destroy(this.gameObject);
            }
        }
    }
}

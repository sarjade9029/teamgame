using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//158//81 17
public class GetCoin : MonoBehaviour
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
        if (other.gameObject.tag == "Player")
        {
            playermovescript.AddScore(100);
            playermovescript.AddCoin(1);
            Destroy(this.gameObject);
        }
    }
}

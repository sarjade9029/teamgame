using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrushEnemy : MonoBehaviour
{
    GameObject Player;
    PlayerMove playermovescript;
    EnemyMove enemy;
    void Start()
    {
        Player = GameObject.Find("player1");
        playermovescript = Player.GetComponent<PlayerMove>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "enemy")
        {
                playermovescript.AddScore(100);
                Destroy(other.gameObject);
        }
    }
}

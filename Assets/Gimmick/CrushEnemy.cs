using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrushEnemy : MonoBehaviour
{
    EnemyMove enemy;
    PlayerMove playermovescript;
    [SerializeField] GameObject Player;
    void Start()
    {
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

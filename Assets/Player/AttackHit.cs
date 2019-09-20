using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHit : MonoBehaviour
{
    GameObject parent;
    PlayerMove playermovescript;
    [SerializeField] GameObject Player;
    void Start()
    {
        playermovescript = Player.GetComponent<PlayerMove>();
        parent = transform.root.gameObject;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "enemy2" || other.gameObject.tag == "enemy")
        {
            if (other.gameObject.transform.localScale.x != Player.transform.localScale.x)
            {
                if (other.gameObject.tag == "enemy")
                {
                    Player.GetComponent<Animator>().SetTrigger("Eat2");
                }
                else
                {
                    Player.GetComponent<Animator>().SetTrigger("Eat");
                }
                playermovescript.AddScore(100);
                Destroy(other.gameObject);
                parent.GetComponent<PlayerAtack>().hit = true;
                Destroy(this.gameObject);
            }
        }
    }
}

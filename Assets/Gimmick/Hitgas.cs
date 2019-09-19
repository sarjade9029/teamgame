using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hitgas : MonoBehaviour
{
    float startTime;
    public float xSpeed = 5.0f;
    public int dmg = 1;
    [SerializeField] GameObject Player;
    [SerializeField] GameObject Player1;
    PlayerMove Playermove;
    private float playerpos;
    private bool hit = false;
    public int hittime = 6;
    private int count;
    // Use this for initialization
    void Start()
    {
        Player = GameObject.Find("player1");
        Playermove = Player.GetComponent<PlayerMove>();
        Player1 = GameObject.Find("player");
    }
    void Update()
    {
        if (hit == true)
        {
            count++;
            if (count >= hittime*60)
            {
                if (Playermove.GetOnGround() == true)
                {
                    PlayerMove player = Player.gameObject.GetComponent<PlayerMove>();
                    //体力減らす
                    player.sleepiness -= dmg;
                    if (player.sleepiness == 0)
                    {
                        Destroy(Player.gameObject);
                        Destroy(Player1.gameObject);
                        Playermove.scorecoininit();
                        SceneManager.LoadScene("GameOver");
                    }
                    count = 0;
                }
                else
                {
                    //体力減らす
                    Playermove.sleepiness -= dmg;
                    if (Playermove.sleepiness == 0)
                    {
                        Destroy(Player1.gameObject);
                        Destroy(Player.gameObject);
                        Playermove.scorecoininit();
                        SceneManager.LoadScene("GameOver");
                    }
                    count = 0;
                }
            }
        }
    }
    //以下不変
    private void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.gameObject.tag == "Player") || other.gameObject.tag == "GasCollider")
        {
            if (Playermove.GetOnGround() == true)
            {
                PlayerMove player = Player.gameObject.GetComponent<PlayerMove>();
                //体力減らす
                player.sleepiness -= dmg;
                if (player.sleepiness == 0)
                {
                    Destroy(Player.gameObject);
                    Destroy(Player1.gameObject);
                    Playermove.scorecoininit();
                    SceneManager.LoadScene("GameOver");
                }
                count = 0;
                hit = true;
            }
            else
            {
                //体力減らす
                Playermove.sleepiness -= dmg;
                if (Playermove.sleepiness == 0)
                {
                    Destroy(Player1.gameObject);
                    Destroy(Player.gameObject);
                    Playermove.scorecoininit();
                    SceneManager.LoadScene("GameOver");
                }
                count = 0;
                hit = true;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if ((other.gameObject.tag == "Player") || other.gameObject.tag == "GasCollider")
        {
            hit = false;
            count = 0;
        }
    }
}

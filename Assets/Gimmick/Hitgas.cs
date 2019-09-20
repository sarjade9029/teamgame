using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hitgas : MonoBehaviour
{
    public int dmg = 1;
    public int hittime = 6;
    public float xSpeed = 5.0f;
    private int count;
    private float startTime;
    private float playerpos;
    private bool hit = false;
    PlayerMove Playermove;
    [SerializeField] GameObject Player;
    [SerializeField] GameObject WallPlayer;
    void Start()
    {
        Playermove = Player.GetComponent<PlayerMove>();
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
                        Destroy(WallPlayer.gameObject);
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
                        Destroy(WallPlayer.gameObject);
                        Destroy(Player.gameObject);
                        Playermove.scorecoininit();
                        SceneManager.LoadScene("GameOver");
                    }
                    count = 0;
                }
            }
        }
    }
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
                    Destroy(WallPlayer.gameObject);
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
                    Destroy(WallPlayer.gameObject);
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

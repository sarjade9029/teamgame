using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGround : MonoBehaviour
{
    GameObject Player1;
    PlayerMove playermovescript;
    // Update is called once per frame
    void Start()
    {
        Player1 = GameObject.Find("player1");
        playermovescript = Player1.GetComponent<PlayerMove>();
    }
    //当たり判定に入ったとき
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "ground")
        {
            Onground(other);
        }
    }
    //当たり判定から抜けたとき
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "ground")
        {
            OnTheWall(other);
        }
    }
    void Onground(Collider2D other)
    {
        playermovescript.OnGround();
        playermovescript.LeaveWall();
    }
    void OnTheWall(Collider2D other)
    {
        playermovescript.LeaveGround();
        playermovescript.OnWall();
    }
}

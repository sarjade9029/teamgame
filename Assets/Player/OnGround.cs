using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGround : MonoBehaviour
{
    PlayerMove playermovescript;
    [SerializeField] GameObject Player;
    void Start()
    {
        playermovescript = Player.GetComponent<PlayerMove>();
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

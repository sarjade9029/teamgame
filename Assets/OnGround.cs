using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        OnGround(other);
    }
    //当たり判定から抜けたとき
    private void OnTriggerExit2D(Collider2D other)
    {
        OnTheWall(other);
    }
    void OnGround(Collider2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            PlayerMove player = other.gameObject.GetComponent<PlayerMove>();
            player.onTheGround = true;
            player.onTheWall = false;
        }
    }
    void OnTheWall(Collider2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            PlayerMove player = other.gameObject.GetComponent<PlayerMove>();
            player.onTheGround = false;
            player.onTheWall = true;
        }
    }

}

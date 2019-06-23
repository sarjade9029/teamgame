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
        if (other.gameObject.tag == "Ground")
        {
            PlayerMove player = other.gameObject.GetComponent<PlayerMove>();
            player.onTheGround = true;
            player.onTheWall = false;
        }
    }
    //当たり判定に入った時
    private void OnTriggerEnter(Collider other)
    {
        
    }
    //当たり判定から抜けたとき
    private void OnTriggerExit(Collider other)
    {
        
    }
}

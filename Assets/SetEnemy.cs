using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetEnemy : MonoBehaviour
{
    Shot shot;
    void Start()
    {
        shot = this.GetComponent<Shot>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            shot.shotflag = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            shot.shotflag = false;
            shot.ResetTime();
        }
    }
}

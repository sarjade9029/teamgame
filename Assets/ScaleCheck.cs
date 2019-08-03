using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleCheck : MonoBehaviour
{
    public GameObject Player;

    // Update is called once per frame
    void Update()
    {
        UpdateScale();
    }
    void UpdateScale()
    {
        this.transform.localScale = Player.transform.localScale;
        //if (Player.transform.localScale.x < 0)
        //{
        //    this.transform.localScale =
        //        new Vector3(Player.transform.localScale.x 
        //        , Player.transform.localScale.y
        //        , Player.transform.localScale.z);
        //}
    }
}

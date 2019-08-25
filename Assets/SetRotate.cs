using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetRotate : MonoBehaviour
{
    public GameObject wallplayer;
    public GameObject collder;
    // Update is called once per frame
    void Update()
    {
        collder.transform.rotation = wallplayer.transform.rotation;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookRange : MonoBehaviour
{
    public float lookRange = 1;

    // Update is called once per frame
    void Start()
    {
        transform.localScale = new Vector3(lookRange, lookRange, 1.0f);
    }
}

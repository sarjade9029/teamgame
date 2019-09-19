using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookRange : MonoBehaviour
{
    public float lookRange = 1;//視界の大きさ
    void Start()
    {
        //視界の大きさを調整
        transform.localScale = new Vector3(lookRange, lookRange, 1.0f);
    }
}

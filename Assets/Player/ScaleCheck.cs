using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleCheck : MonoBehaviour
{
    public GameObject Player;
    void Update()
    {
        UpdateScale();
    }
    void UpdateScale()
    {
        this.transform.localScale = Player.transform.localScale;
    }
}

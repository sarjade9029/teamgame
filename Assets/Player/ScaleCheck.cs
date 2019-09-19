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
    }
}

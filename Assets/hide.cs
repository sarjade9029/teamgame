using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hide : MonoBehaviour
{
    public GameObject gameobject;
    //1.0fで描画0.0fで非表示
    float changeRed = 1.0f;
    float changeGreen = 1.0f;
    float cahngeBlue = 1.0f;
    float cahngeAlpha = 1.0f;
    // Use this for initialization
    void Start()
    {
        changeRed = 1.0f;
        changeGreen = 1.0f;
        cahngeBlue = 1.0f;
        cahngeAlpha = 1.0f;
    }
    // Update is called once per frame
    void Update()
    {
        this.GetComponent().color = new Color(changeRed, changeGreen, cahngeBlue, cahngeAlpha);
    }
}

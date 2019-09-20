//未使用
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Brightness : MonoBehaviour
{
    public float red = 0;
    public float gree = 0;
    public float blue = 0;
    public float foll = 0;
    public float alpha = 1;
    public GameObject Key;
    public GameObject buttonB;
    public GameObject buttonY;
    public GameObject buttonRb;
    Image B;
    Image Y;
    Image RB;
    Image Keyimage;
    PlayerMove playermove;
    [SerializeField] GameObject player;
    void Start()
    {
        playermove = player.GetComponent<PlayerMove>();
        B = buttonB.GetComponent<Image>();
        Y = buttonY.GetComponent<Image>();
        RB = buttonRb.GetComponent<Image>();
        Keyimage = Key.GetComponent<Image>();
    }
    void Update()
    {
        B.color = new Color(red, gree, blue, foll);
        Y.color = new Color(red, gree, blue, foll);
        RB.color = new Color(red, gree, blue, foll);
        if (playermove.GetKeyState() == true)
        {
            Keyimage.color = new Color(1, 1, 1, 1);
        }
        else
        {
            Keyimage.color = new Color(0.43f, 0.43f, 0.43f, 1);
        }
    }
}
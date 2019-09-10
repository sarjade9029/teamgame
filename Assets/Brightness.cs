using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Brightness : MonoBehaviour
{
    public GameObject buttonB;
    public GameObject buttonY;
    public GameObject buttonRb;
    public GameObject Key;
    Image B;
    Image Y;
    Image RB;
    Image Keyimage;
    public float red = 0;
    public float gree = 0;
    public float blue = 0;
    public float alpha = 1;
    public float foll = 0;
    GameObject player;
    PlayerMove playermove;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player1");
        playermove = player.GetComponent<PlayerMove>();
        B = buttonB.GetComponent<Image>();
        Y = buttonY.GetComponent<Image>();
        RB = buttonRb.GetComponent<Image>();
        Keyimage = Key.GetComponent<Image>();
    }
    // Update is called once per frame
    void Update()
    {
        B.color = new Color(red, gree, blue, alpha);
        Y.color = new Color(red, gree, blue, alpha);
        RB.color = new Color(red, gree, blue, alpha);
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
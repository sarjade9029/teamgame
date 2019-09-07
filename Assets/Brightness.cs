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
    public float red;
    public float gree;
    public float blue;
    public float alpha;
    public float foll = 0;
    // Start is called before the first frame update
    void Start()
    {
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
        Keyimage.color = new Color(red, gree, blue, alpha);
    }
}
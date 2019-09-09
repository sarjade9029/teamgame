using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowUI5 : MonoBehaviour
{
    public GameObject flame;
    public GameObject text;
    public string Text;
    Image flameimage;
    Text ui_text;
    public int textnum = 0;
    private float alpha = 1;
    private float zero = 0;
    // Start is called before the first frame update
    void Start()
    {
        flameimage = flame.GetComponent<Image>();
        ui_text = text.GetComponent<Text>();
        ui_text.text = Text;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        flameimage.color = new Color(1, 1, 1, alpha);
        ui_text.color = new Color(0, 0, 0, alpha);
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        flameimage.color = new Color(1, 1, 1, zero);
        ui_text.color = new Color(1, 1, 1, zero);
    }
}
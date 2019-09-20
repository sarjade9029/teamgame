using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowUI : MonoBehaviour
{
    public string Text;
    [SerializeField] GameObject text = null;
    [SerializeField] GameObject flame = null;
    private float zero = 0;
    private float alpha = 1;
    Text ui_text;
    Image flameimage;
    void Start()
    {
        flameimage = flame.GetComponent<Image>();
        ui_text = text.GetComponent<Text>();
        ui_text.text = Text;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            flameimage.color = new Color(1, 1, 1, alpha);
            ui_text.color = new Color(0, 0, 0, alpha);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            flameimage.color = new Color(1, 1, 1, zero);
            ui_text.color = new Color(1, 1, 1, zero);
        }
    }
}

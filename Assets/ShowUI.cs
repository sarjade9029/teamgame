using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowUI : MonoBehaviour
{
    public GameObject flame;
    public GameObject text;
    Image flameimage;
    Text ui_text;
    private float alpha = 1;
    private float zero = 0;
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

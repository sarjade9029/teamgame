using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewText : MonoBehaviour
{
    public GameObject flame;
    public GameObject text;
    public string Text;
    Image flameimage;
    Text ui_text;
    // Start is called before the first frame update
    void Start()
    {
        flameimage = flame.GetComponent<Image>();
        ui_text = text.GetComponent<Text>();
        ui_text.text = Text;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

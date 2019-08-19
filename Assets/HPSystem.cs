using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using UnityEngine.UI;

public class HPSystem : MonoBehaviour
{

    GameObject image;


    // Start is called before the first frame update
    void Start()
    {
        image = GameObject.Find("Image");
    }


    public void HPDown (float current, int max)
    {
        image.GetComponent<Image>().fillAmount = current / max;
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}

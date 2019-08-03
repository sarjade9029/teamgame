using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;




public class Hp : MonoBehaviour
{
    Slider _slider;
    // Start is called before the first frame update
    void Start()
    {
        _slider = GameObject.Find("Slider").GetComponent<Slider>();
        
    }

    float _hp = 0;
    void Update()
    {
        _hp += 0.01f;
        if (_hp > 1)
        {
            _hp = 0;
        }

        


    }

    
    

}
    


    // Update is called once per frame
    //void Update()
   // {
        
   // }


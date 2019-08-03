using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class kuria : MonoBehaviour {

    public GameObject kuria_object = null;
    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log("経過時間(秒)" + Time.time);

        Text kuria_text = kuria_object.GetComponent<Text>();

        kuria_text.text = "クリアタイム";
            


        

       
	}
}

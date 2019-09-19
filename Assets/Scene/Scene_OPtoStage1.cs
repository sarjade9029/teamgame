using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_OPtoStage1 : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        //op
        if (Input.GetButton("joystick button 3") || Input.GetKey(KeyCode.Q))
        {

                SceneManager.LoadScene("stage1");

        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_toOP : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        //stage1から
        if (Input.GetButton("joystick button 3") || Input.GetKey(KeyCode.Q))
        {
            SceneManager.LoadScene("OP");
        }
    }
}

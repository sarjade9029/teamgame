using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_OPtoStage1 : MonoBehaviour
{
    void Update()
    {
        //op
        if (Input.GetButton("joystick button 3") || Input.GetKey(KeyCode.Q))
        {
                SceneManager.LoadScene("stage1");
        }
    }
}
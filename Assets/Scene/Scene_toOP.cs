using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_toOP : MonoBehaviour
{
    void Update()
    {
        if (Input.GetButton("joystick button 3") || Input.GetKey(KeyCode.Q))
        {
            SceneManager.LoadScene("OP");
        }
        if (Input.GetKey(KeyCode.Escape) || Input.GetButton("joystick button 3"))
        {
            Quit();
        }
    }
    void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_STANDALONE
    UnityEngine.Application.Quit();
#endif
    }
}

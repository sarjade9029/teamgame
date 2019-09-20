//デバッグ用
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    void Update()
    {
        if (Input.GetButton("joystick button 0"))
        {
            Debug.Log("擬態");
        }
        if (Input.GetButton("joystick button 1"))
        {
            Debug.Log("擬態");
        }
        if (Input.GetButton("joystick button 2"))
        {
            Debug.Log("button2");
        }
        if (Input.GetButton("joystick button 3"))
        {
            Debug.Log("アクション");
        }
        if (Input.GetButton("joystick button 4"))
        {
            Debug.Log("button4");
        }
        if (Input.GetButton("joystick button 5"))
        {
            Debug.Log("舌を出す");
        }
        if (Input.GetButton("joystick button 6"))
        {
            Debug.Log("button6");
        }
        if (Input.GetButton("joystick button 7"))
        {
            Debug.Log("button7");
        }
        if (Input.GetButton("joystick button 8"))
        {
            Debug.Log("button8");
        }
        if (Input.GetButton("joystick button 9"))
        {
            Debug.Log("button9");
        }
        float button10 = Input.GetAxis("joystick button 10");
        float button11 = Input.GetAxis("joystick button 11");
        if((button10 !=0)||(button11 !=0))
        {
            Debug.Log("移動" + button10 + "," + button11);
        }
        float hori = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");
        if ((hori != 0) || (vert != 0))
        {
            Debug.Log("stick:" + hori + "," + vert);
        }
    }
}
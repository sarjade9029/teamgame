using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NearPlayer : MonoBehaviour
{
    Hide hide;
    GameObject parent;
    SetTomgue tomgleScript;
    RotateObstruct obstruct;
    [SerializeField] GameObject Player;
    void Start()
    {
        tomgleScript = Player.GetComponent<SetTomgue>();
        hide = Player.GetComponent<Hide>();
        parent = transform.root.gameObject;
        obstruct = parent.GetComponent<RotateObstruct>();
    }
    void Update()
    {
        if(obstruct.InputKey==true)
        {
            if (Input.GetKeyDown(KeyCode.E) || Input.GetButtonDown("joystick button 3"))
            {
                obstruct.defeatobstruct = 1;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            tomgleScript.AttackDisallowed();
            //キーが反応しない
            obstruct.InputKey = true;
            if (obstruct.defeatobstruct == 2)
            {
                tomgleScript.AttackPermit();
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (obstruct.defeatobstruct == 2)
            {
                if (hide.Mimicry() == false)
                {
                    tomgleScript.AttackPermit();
                    obstruct.InputKey = false;
                }
            }
            obstruct.InputKey = false;
        }
    }
}
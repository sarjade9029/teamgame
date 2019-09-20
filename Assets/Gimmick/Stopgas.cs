using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stopgas : MonoBehaviour
{
    private bool InputKey = false;
    Hide hide;
    SetTomgue tomgleScript;
    RotateObstruct obstruct;
    [SerializeField] GameObject Player;
    [SerializeField] Transform gas;
    [SerializeField] Transform gaseffect;
    void Start()
    {
        tomgleScript = Player.GetComponent<SetTomgue>();
        hide = Player.GetComponent<Hide>();
    }
    void Update()
    {
        if (InputKey == true)
        {
            if (Input.GetKeyDown(KeyCode.E) || Input.GetButtonDown("joystick button 3"))
            {
                Destroy(gas.gameObject);
                Destroy(gaseffect.gameObject);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            tomgleScript.AttackDisallowed();
            //キーが反応しない
            InputKey = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (hide.Mimicry() == false)
            {
                tomgleScript.AttackPermit();
                InputKey = false;
            }
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stopgas : MonoBehaviour
{
    SetTomgue tomgleScript;
    [SerializeField] GameObject Player;
    [SerializeField] Transform gas;
    [SerializeField] Transform gaseffect;
    RotateObstruct obstruct;
    Hide hide;
    private bool InputKey = false;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("player1");
        tomgleScript = Player.GetComponent<SetTomgue>();
        hide = Player.GetComponent<Hide>();
        gas = transform.Find("gas");
        gaseffect = transform.Find("WhiteSmoke");
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
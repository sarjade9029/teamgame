using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetShot : MonoBehaviour
{
    Viewrotation view;
    GameObject parent;
    Transform rotate;
    Shot shot;

    void Start()
    {
        parent = transform.root.gameObject;
        rotate = parent.transform.Find("rotatepoint");
        view = rotate.GetComponent<Viewrotation>();
        shot = this.GetComponent<Shot>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            view.lookloop = false;
            shot.shotflag = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            shot.shotflag = false;
            view.lookloop = true;
        }
    }
}


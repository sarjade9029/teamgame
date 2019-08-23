using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetShot : MonoBehaviour
{
    Viewrotation view;
    GameObject parent;
    Transform rotate;
    Transform lightcolor;
    Shot shot;
    void Start()
    {
        parent = transform.root.gameObject;
        rotate = parent.transform.Find("rotatepoint");
        lightcolor = rotate.transform.Find("Spot Light (2)");
        view = rotate.GetComponent<Viewrotation>();
        shot = this.GetComponent<Shot>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            view.lookloop = false;
            shot.shotflag = true;
            lightcolor.GetComponent<Light>().color = new Color(1, 1, 0, 1);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            shot.shotflag = false;
            view.lookloop = true;
            shot.ResetTime();
            lightcolor.GetComponent<Light>().color = new Color(1, 1, 1, 1);
        }
    }
}


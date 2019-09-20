using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetShot : MonoBehaviour
{
    Shot shot;
    EnemyMove enemy;
    GameObject parent;
    Viewrotation view;
    [SerializeField] Transform rotate;
    [SerializeField] Transform lightcolor;
    void Start()
    {
        shot = this.GetComponent<Shot>();
        parent = transform.root.gameObject;
        enemy = parent.GetComponent<EnemyMove>();
        view = rotate.GetComponent<Viewrotation>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            view.lookloop = false;
            shot.shotflag = true;
            enemy.Stop();
            lightcolor.GetComponent<Light>().color = new Color(1, 1, 0, 1);//色
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            shot.shotflag = false;
            view.lookloop = true;
            shot.ResetTime();
            enemy.ParmitMove();
            lightcolor.GetComponent<Light>().color = new Color(1, 1, 1, 1);
        }
    }
}
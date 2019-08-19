using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObstruct : MonoBehaviour
{
    int time = 0;
    public bool defeatobstruct = false;
    public bool InputKey = false;
    // Start is called before the first frame update
    void Start()
    {
       
    }
    //検知と実行を分ける
    // Update is called once per frame
    void Update()
    {
        if (defeatobstruct == true)
        {
            if(time<90)
            {
                transform.Rotate(new Vector3(0, 0, -1));
            }
            else
            {
                defeatobstruct = false;
            }
            time++;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObstruct : MonoBehaviour
{
    int time = 0;
    public int defeatobstruct = 0;
    public bool InputKey;
    // Start is called before the first frame update
    //検知と実行を分ける
    // Update is called once per frame
    void Update()
    {
        if (defeatobstruct == 1)
        {
            if(time<90)
            {
                transform.Rotate(new Vector3(0, 0, -1));
            }
            else
            {
                defeatobstruct = 2;
            }
            time++;
        }
    }
}

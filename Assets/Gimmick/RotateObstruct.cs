using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObstruct : MonoBehaviour
{
    public int defeatobstruct = 0;
    public bool InputKey;
    private int time = 0;
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

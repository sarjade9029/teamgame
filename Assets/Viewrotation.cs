﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Viewrotation : MonoBehaviour
{
    public bool lookUp = true;
    public int allTime = 120;
    public int looktime = 0;
    public int lookat;
    public int waittime = 0;
    public int Staringtime = 60;
    public bool lookloop = true;
    void Start()
    {
        lookat = allTime;   
    }
    void Update()
    {
        if (lookloop == true)
        {
            if (lookUp == true)
            {
                if(looktime != allTime)
                {
                    for(int i=0;i<lookat;i++)
                    {
                        if (waittime == 0)
                        {
                            transform.Rotate(new Vector3(0, 0, 1));
                            looktime++;
                            waittime = allTime * 3;
                        }
                        waittime--;
                    }
                }
                if(looktime==allTime)
                {
                    looktime = 0;
                    lookUp = false;
                }
            }
            else
            {
                if (looktime != allTime)
                {
                    for (int i = 0; i < lookat; i++)
                    {
                        if (waittime == 0)
                        {
                            transform.Rotate(new Vector3(0, 0, -1));
                            looktime++;
                            waittime = allTime * 3;
                        }
                        waittime--;
                    }
                }
                if (looktime == allTime)
                {
                    looktime = 0;
                    lookUp = true;
                }
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Viewrotation : MonoBehaviour
{
    public int looktime = 0;        //カウントアップ式
    public int waittime = 0;        //カウントダウン式
    public int allTime = 120;       //上下に動かす時間
    public int ScopeSpeed = 10;     //一回動かすたびに待つ時間
    public bool lookUp = true;      //視界を上に動かすか下に動かすか
    public bool lookloop = true;    //そもそも視界が動くのかどうか
    void Update()
    {
        if (lookloop == true)
        {
            if (lookUp == true)
            {
                if(looktime != allTime)
                {
                    for (int i = 0; i < allTime; i++)
                    {
                        if (waittime == 0)
                        {
                            transform.Rotate(new Vector3(0, 0, 1));
                            looktime++;
                            waittime = ScopeSpeed * 60;
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
                    for (int i = 0; i < allTime; i++)
                    {
                        if (waittime == 0)
                        {
                            transform.Rotate(new Vector3(0, 0, -1));
                            looktime++;
                            waittime = ScopeSpeed * 60;
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
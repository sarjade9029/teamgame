using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    private float time = 0;
    // 生み出すもととなる弾のプレハブ
    public GameObject shotPrefab;
    // ショットを生み出す場所
    public GameObject shotPoint;
    public bool shotflag = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (shotflag == true)
        {
            if (time == 0)
            {
                GameObject newShot = GameObject.Instantiate(shotPrefab);
                // 生み出した弾の位置をショットポジションと同じにする.
                newShot.transform.position = shotPoint.transform.position;
                // 敵が反対を向いている場合は、ショットも反対を向かせる.
                // Xのスケールがマイナスの場合は反対をむく
                if (shotPoint.transform.localScale.x < 0)
                {
                    newShot.transform.localScale =
                        new Vector3(newShot.transform.localScale.x * -1,
                        newShot.transform.localScale.y,
                        newShot.transform.localScale.z);
                }
                time = 180;
            }
            if (time > 0)
            {
                time--;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetShot : MonoBehaviour
{

    // 生み出すもととなる弾のプレハブ
    public GameObject shotPrefab;

    // ショットを生み出す場所
    public GameObject shotPoint;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameObject newShot = GameObject.Instantiate(shotPrefab);
            // 生み出した弾の位置をショットポジションと同じにする.
            newShot.transform.position = shotPoint.transform.position;
            // 敵が反対を向いている場合は、ショットも反対を向かせる.
            // Xのスケールがマイナスの場合は反対をむく
            if (shotPoint.transform.localScale.x < 0)
            {
                newShot.transform.localScale =
                    new Vector3(newShot.transform.localScale.x *-1,
                    newShot.transform.localScale.y,
                    newShot.transform.localScale.z);
            }
        }
    }
}

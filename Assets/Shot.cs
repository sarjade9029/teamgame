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
    GameObject parent;
    public bool shotflag = false;
    GameObject Player;
    PlayerMove Playermove;
    private float playerposy;
    private float playerposx;
    public Animator anim;
    // Update is called once per frame
    void Start()
    {
        parent = shotPoint.transform.root.gameObject;
        anim = parent.GetComponent<Animator>();
        Player = GameObject.Find("player1");
        Playermove = Player.GetComponent<PlayerMove>();
        playerposy = Player.transform.localPosition.y;
        playerposx = Player.transform.localPosition.x;
    }
    void Update()
    {
        if (shotflag == true)
        {
            if (shotPrefab.tag != "enemy2")
            {
                anim.SetTrigger("Attack");
            }
            if (time == 0)
            {
                GameObject newShot = GameObject.Instantiate(shotPrefab);
                // 生み出した弾の位置をショットポジションと同じにする.
                newShot.transform.position = shotPoint.transform.position;
                // 敵が反対を向いている場合は、ショットも反対を向かせる.
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
    public void ResetTime()
    {
        time = 0;
    }
}
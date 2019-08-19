using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Change : MonoBehaviour

{
    public GameObject gameObject1;
    public GameObject gameObject2;
    public GameObject gameObject3;
    public GameObject gameObject4;
    public GameObject gameObject5;

    /// <summary>
    /// トリガーに何かが入った時に呼ばれるプログラム
    /// </summary>
    private void OnTriggerEnter2D(Collider2D other)
    {
        // プレイヤーにぶつかったとき
        if (other.gameObject.tag == "Player")
        {
            // ボールを見える状態にするチェックを付ける
            if (gameObject1 != null) gameObject1.SetActive(true);
            if (gameObject2 != null) gameObject2.SetActive(false);
            if (gameObject3 != null) gameObject3.SetActive(false);
            if (gameObject4 != null) gameObject4.SetActive(false);
            if (gameObject5 != null) gameObject5.SetActive(false);
        }
    }
}



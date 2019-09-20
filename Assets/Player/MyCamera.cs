using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCamera : MonoBehaviour {

    public float StageEnd=0.0f;
    public float StageStart = -12.8f;
    public GameObject target;
	void Update () {
        // ターゲットを追いかける
        if (target.transform.position.x > StageStart && target.transform.position.x < StageEnd)
        {
            transform.position = new Vector3(target.transform.position.x, transform.position.y, transform.position.z);
        }
	}
}

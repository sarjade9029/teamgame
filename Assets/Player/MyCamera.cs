using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCamera : MonoBehaviour {

    public GameObject target;
    public float StageStart = -12.8f;
    public float StageEnd=0.0f;
	// Update is called once per frame
	void Update () {
        // ターゲットを追いかける
        if (target.transform.position.x > StageStart && target.transform.position.x < StageEnd)
        {
            transform.position = new Vector3(target.transform.position.x, transform.position.y, transform.position.z);
        }
	}
}

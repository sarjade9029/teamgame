using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTomgue : MonoBehaviour
{
    //生成
    public GameObject Tongue;
    public GameObject PlayerPos;
    private bool extend = false;
    // Update is called once per frame
    void Update()
    {
        KeyInput();
    }
    void KeyInput()
    {
        if (Input.GetKeyDown(KeyCode.E) && extend == false)
        {
            extend = true;
            //ショットのゲームオブジェクトをコピーする
            //コピーした物をnewshotに入れる
            GameObject newAttack = GameObject.Instantiate(Tongue);

            //mewshotの位置をプレイヤーと同じにする
            newAttack.transform.position = 
                new Vector3(PlayerPos.transform.position.x,
                PlayerPos.transform.position.y,
                PlayerPos.transform.position.z + 1);
                //PlayerPos.transform.position;

            //向きを同じにする
            newAttack.transform.rotation = gameObject.transform.rotation;
        }
    }
    public void ExtendEnd()
    {
        extend = false;
    }
}

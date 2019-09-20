using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class DamageSystem1 : MonoBehaviour
{
    GameObject textObj;
    PlayerMove playerhp;
    [SerializeField] int maxHP = 13;
    [SerializeField] float currentHP;//現在値
    [SerializeField] Text text;
    [SerializeField] GameObject player;
    [SerializeField] GameObject hpSystem;
    void Start()
    {
        playerhp = player.GetComponent<PlayerMove>();
    }
    void Update()
    {
        textObj.GetComponent<Text>().text = ((int)currentHP).ToString();
        hpSystem.GetComponent<HPSystem>().HPDown(currentHP, maxHP);
    }
    void FixedUpdate()
    {
        if (0 <= currentHP)
        {
            currentHP = playerhp.sleepiness;
        }
    }
}

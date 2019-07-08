using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Othergraph : MonoBehaviour
{
    private float graphA = 1.0f;
    private float graphB = 0.0f;
    private float hidden = 0.0f;
    private float display = 1.0f;
    // Start is called before the first frame update
    SpriteRenderer spriteRenderer;
    GameObject other;
    SpriteRenderer otherSpriteRenderer;
    void Start()
    {
        other = GameObject.Find("");
        otherSpriteRenderer = other.GetComponent<SpriteRenderer>();
        this.spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //GetComponent<PolygonCollider2D>().enabled = hit;
    }
}

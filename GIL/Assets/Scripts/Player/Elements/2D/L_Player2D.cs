using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class L_Player2D : MonoBehaviour
{
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        CircleCollider2D collider = this.GetComponent<CircleCollider2D>();
        collider.sharedMaterial.friction = 0f;
        this.gameObject.layer = 10;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

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
        var physic = rb.sharedMaterial;

        physic.friction = 0.9f;
        this.gameObject.layer = 10;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

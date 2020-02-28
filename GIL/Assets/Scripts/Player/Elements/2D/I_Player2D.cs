using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class I_Player2D : MonoBehaviour
{
    Rigidbody2D rb = null;
    [SerializeField]
    float addGravity = 0f;
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        CircleCollider2D collider = this.GetComponent<CircleCollider2D>();
        PhysicsMaterial2D material = collider.sharedMaterial;
        material.friction = 0.01f;
        collider.sharedMaterial = material;
        this.gameObject.layer = 12;
    }

    private void Update()
    {
        // 追加で重力を加える
        rb.AddForce(-transform.up * addGravity);
    }
}

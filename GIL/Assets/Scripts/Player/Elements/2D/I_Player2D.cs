using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class I_Player2D : MonoBehaviour
{
    Rigidbody2D rb = null;
    [SerializeField]
    float addGravity = 4f;
    void Start()
    {
        this.gameObject.layer = 12;
        rb = this.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // 追加で重力を加える
        rb.AddForce(-transform.up * addGravity);
    }
}

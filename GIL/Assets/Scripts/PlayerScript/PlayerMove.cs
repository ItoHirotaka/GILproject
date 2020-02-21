﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //上限値
    [SerializeField]
    public float MaxPow;
    //加算の値
    [SerializeField]
    float thrust;
    [SerializeField]
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    { 
        thrust = 30.0f;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 force = new Vector3(thrust, 0.0f, 0.0f);
        // 左に移動
        if (Input.GetKey(KeyCode.A) && rb.velocity.magnitude < MaxPow)
        {
            rb.AddForce(-force); // 力を加える
        }
        // 右に移動
        if (Input.GetKey(KeyCode.D) && rb.velocity.magnitude < MaxPow)
        {
            rb.AddForce(force); // 力を加える
        }
    }
}
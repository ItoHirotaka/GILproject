using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //加算の値
    [SerializeField]
    float thrust;
    //加算結果
    [SerializeField]
    float Speed;
    [SerializeField]
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        thrust = 0.1f;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Speed < 0.5)
        {
            Speed  += thrust;
        }
        // 左に移動
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(-Speed, 0, 0, ForceMode.Impulse);
        }
        // 右に移動
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Speed, 0, 0, ForceMode.Impulse);
        }
        else if (!Input.GetKey(KeyCode.A) && !Input.GetKeyUp(KeyCode.D) && Speed > 0) 
        {
            Speed -= 0.1f;
        }
        Debug.Log(Speed);
    }
}

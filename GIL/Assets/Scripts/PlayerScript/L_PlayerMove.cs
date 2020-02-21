using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L_PlayerMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // 右移動時
        transform.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 10);
        // 左移動時
        transform.GetComponent<Rigidbody2D>().AddForce(Vector2.left * 10);
        
    }
    // Update is called once per frame
    void Update()
    {
       
    }
}

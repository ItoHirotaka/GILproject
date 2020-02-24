using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class G_Player2D : MonoBehaviour
{
    [SerializeField]
    float MaxSpeed = 11f; // テスト段階での数値。Inspectorで調整してください
    [SerializeField]
    float Speed = 11f; // テスト段階での数値。Inspectorで調整してください
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        this.gameObject.layer = 11;
        
    }

    // Update is called once per frame
    void Update()
    {
        bool canMove_U = rb.velocity.y < MaxSpeed;
        if (canMove_U)
        {
            rb.AddForce(Vector3.up * Speed);
        }
        //// transformを取得
        //Transform myTransform = this.transform;
        //// 現在の座標からのxyz を1ずつ加算して移動
        //myTransform.Translate(0f, Speed, 0f);
    }
}

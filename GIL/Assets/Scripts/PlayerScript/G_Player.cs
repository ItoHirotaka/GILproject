using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G_Player : MonoBehaviour
{
    private float Speed;
    // Start is called before the first frame update
    void Start()
    {
        Speed = 0.025f;
    }

    // Update is called once per frame
    void Update()
    {
        // transformを取得
        Transform myTransform = this.transform;
        // 現在の座標からのxyz を1ずつ加算して移動
        myTransform.Translate(0f, Speed, 0f);
    }
}

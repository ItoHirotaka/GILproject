using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_PlayerControler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public float speed;
    void Move()
    {
        if (Input.GetKey(KeyCode.A)) this.transform.Translate(-speed, 0f, 0f);
        if (Input.GetKey(KeyCode.D)) this.transform.Translate(speed, 0f, 0f);
    }
}

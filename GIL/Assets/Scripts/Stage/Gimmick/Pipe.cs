using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    [SerializeField]
    GameObject outPos;
    Transform tr;
    // Start is called before the first frame update
    void Start()
    {
        tr = outPos.transform;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 10)
        {
            collision.transform.position = tr.position;
        }
    }
}

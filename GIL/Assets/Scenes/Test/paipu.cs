using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class paipu : MonoBehaviour
{
    [SerializeField]
    GameObject outPos;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.transform.position = outPos.transform.position;
    }
}

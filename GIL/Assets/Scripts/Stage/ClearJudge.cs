using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearJudge : MonoBehaviour
{
    public bool IsClear { get; private set; }

    private void Start()
    {
        IsClear = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            IsClear = true;
        }
    }
}

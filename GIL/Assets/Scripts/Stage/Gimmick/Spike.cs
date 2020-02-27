using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    GameSystem2D GameSystem;
    // Start is called before the first frame update
    void Start()
    {
        GameObject system = GameObject.Find("GameSystem");
        GameSystem = system.GetComponent<GameSystem2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 12)
        {
            GameSystem.Death();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sponge : MonoBehaviour
{
    GameSystem2D GameSystem;
    // Start is called before the first frame update
    void Start()
    {
        GameObject system = GameObject.Find("GameSystem");
        GameSystem = system.GetComponent<GameSystem2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 10)
        {
            GameSystem.Death();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    GameSystem2D GameSystem;
    // Start is called before the first frame update
    void Start()
    {
        GameObject system = GameObject.Find("GameSystem");
        GameSystem = system.GetComponent<GameSystem2D>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 11)
        {
            GameSystem.Death();
        }
    }
}

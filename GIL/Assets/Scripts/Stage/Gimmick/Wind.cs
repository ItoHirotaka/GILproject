using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G_desu : MonoBehaviour
{
    GameSystem2D GameSystem;

    // Start is called before the first frame update
    void Start()
    {
        GameObject system = GameObject.Find("GameSystem");
        GameSystem = system.GetComponent<GameSystem2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer==11)
        {
            GameSystem.Death();
        }
    }
}

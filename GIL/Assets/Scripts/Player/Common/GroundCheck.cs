using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    const int ICE_LAYER = 12;
    GameObject gameSystem = null;
    GameObject player = null;
    Rigidbody2D rb = null;
    private void Start()
    {
        gameSystem = GameObject.Find("GameSystem");
        player = GameObject.Find("Player");
        rb = player.GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isDeath())
        {
            gameSystem.GetComponent<GameSystem2D>().Death();
        }
    }

    [SerializeField]
    float DeathSpeed = 7.2f;  // 死亡判定にする速さ
    bool isDeath()
    {
        bool isDeathSpeed = rb.velocity.y < -DeathSpeed;
        bool isIce = player.layer == ICE_LAYER;
        return isDeathSpeed && isIce;
    }
}

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
        bool isGround = collision.gameObject.tag == "Stage";
        if (isGround && isDeath())
        {
            gameSystem.GetComponent<GameSystem2D>().Death();
        }
    }

    [SerializeField]
    float DeathFall = -13f;  // 死亡判定にする速さ
    bool isDeath()
    {
        bool isDeathHight = rb.velocity.y < DeathFall;
        bool isIce = player.layer == ICE_LAYER;
        return isDeathHight && isIce;
    }
}

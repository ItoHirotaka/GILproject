using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearJudge2D : MonoBehaviour
{
    [SerializeField]
    GameObject GameSystem = null;
    GameSystem2D gameSystem;

    private void Start()
    {
        // コンポーネントの取得
        gameSystem = GameSystem.GetComponent<GameSystem2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Judge通過");
            gameSystem.Clear();
        }
    }
}

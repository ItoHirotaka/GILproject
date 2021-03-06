﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearJudge2D : MonoBehaviour
{
    GameSystem2D gameSystem;

    private void Start()
    {
        // コンポーネントの取得
        GameObject GameSystem = GameObject.Find("GameSystem");
        gameSystem = GameSystem.GetComponent<GameSystem2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gameSystem.Clear();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearJudge : MonoBehaviour
{
    [SerializeField]
    GameObject GameSystem = null;
    GameSystem gameSystem;

    private void Start()
    {
        // コンポーネントの取得
        gameSystem = GameSystem.GetComponent<GameSystem>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            gameSystem.Clear();
        }
    }
}

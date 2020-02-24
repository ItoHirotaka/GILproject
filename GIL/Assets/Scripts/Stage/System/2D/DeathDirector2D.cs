using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathDirector2D : MonoBehaviour
{
    [SerializeField]
    GameObject FadeImage = null;
    FadeUi fadeUi;

    [SerializeField]
    GameObject player = null;

    bool isDeath;
    void Start()
    {
        // コンポーネントの取得
        fadeUi = FadeImage.GetComponent<FadeUi>();
        // 死亡状態の初期化
        isDeath = false;
    }

    void Update()
    {
        if (isDeath)
        {
            UpdateDeath();
        }
    }

    [SerializeField]
    float DontControlTime = 4f; // テストの値です。Inspectorで調整してください
    float count;
    // 死亡状態をセット
    public void Death()
    {
        // 死亡フラグを立てる
        isDeath = true;
        // 演出時間の初期化
        count = DontControlTime;
        // フェードイン
        fadeUi.ChangeState(FadeUi.FadeState.FadeIn);
        // プレイヤーの操作を無効化
        player.GetComponent<PlayerController2D>().UseControl(false);
    }

    // 死亡時の更新処理
    void UpdateDeath()
    {
        count -= Time.deltaTime;
        // 時間経過でゲームメインをロード
        if (count < 0f)
        {
            SceneManager.LoadScene("GameMain2D");
        }
    }
}

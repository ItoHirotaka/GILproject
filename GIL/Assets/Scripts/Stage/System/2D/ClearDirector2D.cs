using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearDirector2D : MonoBehaviour
{
    [SerializeField]
    GameObject FadeImage = null;
    FadeUi fadeUi;

    [SerializeField]
    GameObject player = null;
    Transform playerTr;

    bool isClear;

    void Start()
    {
        // コンポーネントの取得
        fadeUi = FadeImage.GetComponent<FadeUi>();
        playerTr = player.transform;
        // 開始状態の初期化
        isClear = false;
    }

    void Update()
    {
        if (isClear)
        {
            UpdateClear();
        }
    }

    [SerializeField]
    float DontControlTime = 4f; // テストの値です。Inspectorで調整してください
    float count;
    // ゲーム状態を変更する
    public void Clear()
    {
        // クリアフラグを立てる
        isClear = true;
        // 演出時間の初期化
        count = DontControlTime;
        // フェードイン
        fadeUi.ChangeState(FadeUi.FadeState.FadeIn);
        // プレイヤーの操作を無効化
        player.GetComponent<PlayerController2D>().UseControl(false);
    }

    // ゲームクリア時の更新処理
    void UpdateClear()
    {
        count -= Time.deltaTime;
        // 時間経過でゲームメインをロード
        if (count < 0f)
        {
            SceneManager.LoadScene("Title");
        }
    }
}

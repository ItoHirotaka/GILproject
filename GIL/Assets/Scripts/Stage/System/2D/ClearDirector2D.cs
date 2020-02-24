using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    // ゲーム状態を変更する
    public void Clear()
    {
        // クリアフラグを立てる
        isClear = true;
        // フェードイン
        fadeUi.ChangeState(FadeUi.FadeState.FadeIn);
        // プレイヤーの操作を無効化
        player.GetComponent<PlayerController2D>().UseControl(false);
    }

    // ゲームクリア時の更新処理
    void UpdateClear()
    {

    }
}

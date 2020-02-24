using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDirector2D : MonoBehaviour
{
    [SerializeField]
    GameObject FadeImage = null;
    FadeUi fadeUi;

    [SerializeField]
    GameObject player = null;
    Transform playerTr;

    [SerializeField]
    GameObject startPos = null;

    bool isStart;

    void Start()
    {
        // コンポーネントの取得
        fadeUi = FadeImage.GetComponent<FadeUi>();
        playerTr = player.transform;
        // 開始状態の初期化
        isStart = false;
        // 開始前の演出を初期化
        InitBeginGame();
    }

    void Update()
    {
        if (!isStart)
        {
            UpdateBegin();
        }
    }

    // ゲーム状態を変更する
    public void StartGame()
    {
        // プレイヤーの操作を有効化
        player.GetComponent<PlayerController2D>().UseControl(true);
        // コンポーネントの削除
        Destroy(this.gameObject.GetComponent<StartDirector2D>());
    }

    [SerializeField]
    float DontControlTime = 3f; // テストの値です。Inspectorで調整してください
    float count;
    // ゲーム開始前の初期化処理
    void InitBeginGame()
    {
        // 演出時間の初期化
        count = DontControlTime;
        // フェードアウト
        fadeUi.ChangeState(FadeUi.FadeState.FadeOut);
        // プレイヤーを初期位置に移動
        playerTr.position = startPos.transform.position;
        // プレイヤーの操作を無効化
        player.GetComponent<PlayerController2D>().UseControl(false);
    }

    // ゲーム開始前の更新処理
    void UpdateBegin()
    {
        count -= Time.deltaTime;
        // 時間経過でゲーム開始
        if (count < 0f)
        {
            StartGame();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSystem : MonoBehaviour
{
    [SerializeField]
    GameObject FadeImage;
    FadeUi fadeUi;

    [SerializeField]
    GameObject player;
    Transform playerTr;

    void Start()
    {
        //コンポーネントの取得
        fadeUi = FadeImage.GetComponent<FadeUi>();
        playerTr = player.GetComponent<Transform>();

        //開始時の演出
        StartGame();
    }

    void Update()
    {
        
    }

    [SerializeField]
    GameObject startPos;
    void StartGame()
    {
        //フェードアウト
        fadeUi.ChangeState(FadeUi.FadeState.FadeOut);

        //プレイヤーを初期位置に移動
        playerTr.position = startPos.transform.position;
    }
}

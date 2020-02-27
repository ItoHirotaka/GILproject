using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSystem : MonoBehaviour
{
    [SerializeField]
    GameObject Canvas;
    TitleCanvas canvas;

    [SerializeField]
    GameObject FadeImage = null;
    FadeUi fadeUi;

    // カウント開始のフラグ
    bool isStart;

    //カウントアップ
    private float countup = 0.0f;

    //タイムリミット
    [SerializeField]
    float timeLimit = 4.0f;

    // Start is called before the first frame update
    void Start()
    {
        // コンポーネントの取得
        canvas = Canvas.GetComponent<TitleCanvas>();
        fadeUi = FadeImage.GetComponent<FadeUi>();
        // フェードアウト
        fadeUi.ChangeState(FadeUi.FadeState.FadeOut);

        // カウントの初期化
        countup = 0f;
        isStart = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            fadeUi.ChangeState(FadeUi.FadeState.FadeIn);
            isStart = true;
        }

        // 時間をカウントする
        if (isStart == true)
        {
            countup += Time.deltaTime;
            if (countup > timeLimit)
            {
                StartGame(canvas.currentNum);
            }
        }
    }

    public void StartGame(int _stageNum)
    {
        PlayerPrefs.SetInt("StageNum", _stageNum);
        SceneManager.LoadScene("GameMain2D");
    }
}

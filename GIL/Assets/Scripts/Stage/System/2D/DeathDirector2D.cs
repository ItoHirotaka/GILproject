using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathDirector2D : MonoBehaviour
{

    //死亡音
    public AudioClip DeathSound;
    AudioSource audioSource;

    [SerializeField]
    GameObject FadeImage = null;
    FadeUi fadeUi;

    [SerializeField]
    GameObject Elemental = null;
    ElementalCanvas elementalCanvas;

    [SerializeField]
    GameObject player = null;

    //イメージを取得
    [SerializeField]
    GameObject image_object;
    [SerializeField]
    Image image;

    //画像のカラー取得
    float red, green, blue, alpha;

    bool isDeath;
    void Start()
    {
        // コンポーネントの取得
        fadeUi = FadeImage.GetComponent<FadeUi>();
        elementalCanvas = Elemental.GetComponent<ElementalCanvas>();
        // 死亡状態の初期化
        isDeath = false;
        //音のコンポーネントを取得
        audioSource = GetComponent<AudioSource>();
        // オブジェクトの取得
        image_object = GameObject.Find("Image");
        red = image.color.r;
        green = image.color.g;
        blue = image.color.b;
        alpha = image.color.a;
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
    //アルファ値の最大値
    float MaxAlpha = 255f;
    // 死亡状態をセット
    public void Death()
    {
        // 死亡フラグを立てる
        isDeath = true;
        // 演出時間の初期化
        count = DontControlTime;
        // 属性画像を非表示
        elementalCanvas.Death();
        // フェードイン
        fadeUi.ChangeState(FadeUi.FadeState.FadeIn);
        // プレイヤーの操作を無効化
        player.GetComponent<PlayerController2D>().UseControl(false);
        //音出力
        audioSource.PlayOneShot(DeathSound);
        alpha = MaxAlpha;
        SetAlpha();
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
    void SetAlpha()//アルファ値の変更
    {
        image.color = new Color(red, green, blue, alpha);
    }
}
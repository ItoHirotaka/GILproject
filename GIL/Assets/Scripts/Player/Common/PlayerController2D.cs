using UnityEngine;

public enum PlayerStateEnum2D
{
    NONE = 0,
    LIQUID,
    ICE,
    STEAM,
};

[RequireComponent(typeof(Rigidbody2D))] // Rigidbody追加
[RequireComponent(typeof(Collider2D))]  // Collider追加
                                        // スクリプトアタッチ
[RequireComponent(typeof(PlayerDataProvider2D))]

public class PlayerController2D : MonoBehaviour
{
    public PlayerStateEnum2D playerState { get; private set; } // 自機の状態
    public bool canControl { get; private set; }    // 操作状態を管理

    // 上限値
    [SerializeField]
    public float MaxPow;
    // 加算の値
    [SerializeField]
    float thrust;
    [SerializeField]
    public Rigidbody2D rb;

    // BodyのPrefab
    [SerializeField]
    GameObject liquidPref;
    [SerializeField]
    GameObject icePref;
    [SerializeField]
    GameObject steamPref;

    // 属性変更用
    ElementalCanvas elementalCanvas;
    // 効果音用
    TransformSound sound;
    // アニメーション管理用
    public bool IsMove { get; private set; }

    void Start()
    {
        // 状態を初期化し、Bodyを生成
        playerState = PlayerStateEnum2D.NONE;
        ChangeState();

        // コンポーネントの取得
        rb = this.GetComponent<Rigidbody2D>();
        GameObject canvas = GameObject.Find("ElementalCanvas");
        elementalCanvas = canvas.GetComponent<ElementalCanvas>();
        sound = this.GetComponent<TransformSound>();
    }

    private void FixedUpdate()
    {
        // アニメーション用移動フラグを落とす
        IsMove = false;
        // 操作出来る状態なら
        if (canControl)
        {
            // 移動処理
            Move();
        }
    }

    void Update()
    {
        // 操作出来る状態なら
        if (canControl)
        {
            // 状態変更
            if (Input.GetKeyDown(KeyCode.Return))
            {
                ChangeState();
                elementalCanvas.ChangeImage(playerState);
                sound.PlaySound();
            }
        }
    }

    // 移動処理
    void Move()
    {
        // X軸方向の入力を取得(-1 ～ 1)
        float Hori = Input.GetAxis("Horizontal");

        if (Hori == 0f) // X軸の入力がなければ終了
        {
            return;
        }
        else if (Hori < 0f) // 左方向の入力がある時
        {
            // アニメーション用移動フラグ
            IsMove = true;
            // 移動処理
            bool canMove_L = rb.velocity.x > -MaxPow;
            if (canMove_L)
            {
                // 力を加える
                Vector3 force = new Vector3(thrust * Hori, 0.0f, 0.0f);
                rb.AddForce(force);
            }
            // モデルの向きを変更
            TurnModel(true);
        }
        else // 右方向の入力がある時
        {
            // アニメーション用移動フラグ
            IsMove = true;
            // 移動処理
            bool canMove_R = rb.velocity.x < MaxPow;
            if (canMove_R)
            {
                // 力を加える
                Vector3 force = new Vector3(thrust * Hori, 0.0f, 0.0f);
                rb.AddForce(force);
            }
            // モデルの向きを変更
            TurnModel(false);
        }
    }

    // モデルの向きを左右反転させる
    void TurnModel(bool _isLeft)
    {
        // 子オブジェクトからBodyを取得
        foreach (Transform c in this.transform)
        {
            // 取得した子オブジェクトのタグが"Body"の場合、左右を反転させる
            if (c.tag == "Body")
            {
                Vector3 vec = c.transform.localScale;
                bool isTurn_L = _isLeft && vec.x > 0f;
                bool isTurn_R = !_isLeft && vec.x < 0f;
                if (isTurn_L || isTurn_R)
                {
                    vec.x *= -1f;
                }
                c.transform.localScale = vec;
                break;
            }
        }
    }

    // プレイヤーの状態を変化させる
    void ChangeState()
    {
        // 次の状態をセット
        SetNextState();
        // 新しいBodyを生成
        ChangeBody();
        // 新しい状態のコンポーネントへ切り替える
        ChangeFoamComponent();
    }

    // 現在の状態を見て、次の状態をセットする
    void SetNextState()
    {
        switch (playerState)
        {
            case PlayerStateEnum2D.NONE: playerState = PlayerStateEnum2D.LIQUID; break;
            case PlayerStateEnum2D.LIQUID: playerState = PlayerStateEnum2D.ICE; break;
            case PlayerStateEnum2D.ICE: playerState = PlayerStateEnum2D.STEAM; break;
            case PlayerStateEnum2D.STEAM: playerState = PlayerStateEnum2D.LIQUID; break;
            default: SendMessage("存在しないプレイヤーの状態です"); break;
        }
    }

    //前の状態のコンポーネントを外し、新しいコンポーネントをセットする
    void ChangeFoamComponent()
    {
        switch (playerState)
        {
            case PlayerStateEnum2D.LIQUID:
                Destroy(this.GetComponent<G_Player2D>());
                this.gameObject.AddComponent<L_Player2D>();
                break;
            case PlayerStateEnum2D.ICE:
                Destroy(this.GetComponent<L_Player2D>());
                this.gameObject.AddComponent<I_Player2D>();
                break;
            case PlayerStateEnum2D.STEAM:
                Destroy(this.GetComponent<I_Player2D>());
                this.gameObject.AddComponent<G_Player2D>();
                break;
            default:
                SendMessage("存在しないプレイヤーの状態です");
                break;
        }
    }

    // 現在の状態を見て、新しいBodyに変更する
    void ChangeBody()
    {
        bool isLeft = false; // 現在の向きを保存する変数

        // 現在のBodyを破壊
        foreach (Transform c in this.transform)
        {
            // 取得した子オブジェクトのタグが"Body"の場合破壊する
            if (c.tag == "Body")
            {
                if (c.localScale.x < 0f) isLeft = true;
                GameObject.Destroy(c.gameObject);
                break;
            }
        }

        // Bodyを生成
        GameObject body = null;
        switch (playerState)
        {
            case PlayerStateEnum2D.LIQUID: body = Instantiate(liquidPref, this.transform); break;
            case PlayerStateEnum2D.ICE: body = Instantiate(icePref, this.transform); break;
            case PlayerStateEnum2D.STEAM: body = Instantiate(steamPref, this.transform); break;
            default: SendMessage("存在しないプレイヤーの状態です"); break;
        }

        // 生成したBodyを子に設定
        body.transform.SetParent(this.gameObject.transform);

        // Bodyの向きを変更
        if (isLeft)
        {
            Vector3 vec = body.transform.localScale;
            vec.x *= -1f;
            body.transform.localScale = vec;
        }
    }

    // プレイヤーの操作状態を設定する
    public void UseControl(bool _isUse)
    {
        canControl = _isUse;
    }
}

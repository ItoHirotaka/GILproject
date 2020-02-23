using UnityEngine;

public enum PlayerStateEnum
{
    NONE = 0,
    LIQUID,
    ICE,
    STEAM,
};

[RequireComponent(typeof(Rigidbody2D))] // Rigidbody追加
[RequireComponent(typeof(Collider))]    // Collider追加
 // スクリプトアタッチ
[RequireComponent(typeof(PlayerDataProvider))]

public class PlayerController : MonoBehaviour
{
    public PlayerStateEnum playerState { get; private set; } // 自機の状態

    // 上限値
    [SerializeField]
    public float MaxPow;
    // 加算の値
    [SerializeField]
    float thrust;
    [SerializeField]
    public Rigidbody rb;
    // モデルが右を向いているかを管理する
    bool isRightModel;

    // BodyのPrefab
    [SerializeField]
    GameObject liquidPref;
    [SerializeField]
    GameObject icePref;
    [SerializeField]
    GameObject steamPref;

    void Start()
    {
        // コンポーネントの取得
        rb = this.GetComponent<Rigidbody>();
        // モデルの向きを初期化
        isRightModel = true;
        // 状態を初期化し、Bodyを生成
        playerState = PlayerStateEnum.NONE;
        ChangeState();
    }

    private void FixedUpdate()
    {
        // 移動処理
        Move();
    }

    void Update()
    {
        // 状態変更
        if (Input.GetKeyDown(KeyCode.Return))
        {
            ChangeState();
        }
    }

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
            // 移動処理
            bool canMove_L = rb.velocity.x > -MaxPow;
            if (canMove_L)
            {
                // 力を加える
                Vector3 force = new Vector3(thrust * Hori, 0.0f, 0.0f);
                rb.AddForce(force);
            }

            // モデルの向きを変える
            if (isRightModel)
            {
                isRightModel = false;
                TurnModel();
            }
        }
        else // 右方向の入力がある時
        {
            // 移動処理
            bool canMove_R = rb.velocity.x < MaxPow;
            if (canMove_R)
            {
                // 力を加える
                Vector3 force = new Vector3(thrust * Hori, 0.0f, 0.0f);
                rb.AddForce(force);
            }

            // モデルの向きを変える
            if (!isRightModel)
            {
                isRightModel = true;
                TurnModel();
            }
        }
    }

    // モデルの向きを左右反転させる
    void TurnModel()
    {
        // 子オブジェクトからBodyを取得
        foreach (Transform c in this.transform)
        {
            // 取得した子オブジェクトのタグが"Body"の場合、左右を反転させる
            if (c.tag == "Body")
            {
                Vector3 vec = c.transform.localScale;
                vec.x *= -1f;
                c.transform.localScale = vec;
                break;
            }
        }
    }

    void ChangeState()
    {
        // 次の状態をセット
        SetNextState();
        // 新しい状態のコンポーネントへ切り替える
        ChangeFoamComponent();
        // 新しいBodyを生成
        ChangeBody();
    }

    // 現在の状態を見て、次の状態をセットする
    void SetNextState()
    {
        switch (playerState)
        {
            case PlayerStateEnum.NONE: playerState = PlayerStateEnum.LIQUID; break;
            case PlayerStateEnum.LIQUID: playerState = PlayerStateEnum.ICE; break;
            case PlayerStateEnum.ICE: playerState = PlayerStateEnum.STEAM; break;
            case PlayerStateEnum.STEAM: playerState = PlayerStateEnum.LIQUID; break;
            default: SendMessage("存在しないプレイヤーの状態です"); break;
        }
    }

    //前の状態のコンポーネントを外し、新しいコンポーネントをセットする
    void ChangeFoamComponent()
    {
        switch (playerState)
        {
            case PlayerStateEnum.LIQUID :
                Destroy(this.GetComponent<G_Player>());
                this.gameObject.AddComponent<L_Player>();
                break;
            case PlayerStateEnum.ICE    :
                Destroy(this.GetComponent<L_Player>());
                this.gameObject.AddComponent<I_Player>();
                break;
            case PlayerStateEnum.STEAM  :
                Destroy(this.GetComponent<I_Player>());
                this.gameObject.AddComponent<G_Player>();
                break;
            default:
                SendMessage("存在しないプレイヤーの状態です");
                break;
        }
    }

    // 現在の状態を見て、新しいBodyに変更する
    void ChangeBody()
    {
        // 現在のBodyを破壊
        foreach (Transform c in this.transform)
        {
            // 取得した子オブジェクトのタグが"Body"の場合破壊する
            if (c.tag == "Body")
            {
                GameObject.Destroy(c.gameObject);
                break;
            }
        }

        // Bodyを生成
        switch (playerState)
        {
            case PlayerStateEnum.LIQUID : Instantiate(liquidPref, this.transform); break;
            case PlayerStateEnum.ICE    : Instantiate(icePref, this.transform); break;
            case PlayerStateEnum.STEAM  : Instantiate(steamPref, this.transform); break;
            default: SendMessage("存在しないプレイヤーの状態です"); break;
        }
    }
}

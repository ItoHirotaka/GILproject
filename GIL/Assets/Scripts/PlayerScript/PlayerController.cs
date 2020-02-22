using UnityEngine;

public enum PlayerStateEnum
{
    LIQUID = 0,
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
        // 状態を初期化し、Bodyを生成
        playerState = PlayerStateEnum.LIQUID;
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
            bool canMove_L = rb.velocity.x > -MaxPow;

            if (canMove_L)
            {
                // 力を加える
                Vector3 force = new Vector3(thrust * Hori, 0.0f, 0.0f);
                rb.AddForce(force);
            }
        }
        else // 右方向の入力がある時
        {
            bool canMove_R = rb.velocity.x < MaxPow;

            if (canMove_R)
            {
                // 力を加える
                Vector3 force = new Vector3(thrust * Hori, 0.0f, 0.0f);
                rb.AddForce(force);
            }
        }
    }

    void ChangeState()
    {
        // 状態の変更
        switch (playerState)
        {
            case PlayerStateEnum.LIQUID: playerState = PlayerStateEnum.ICE; break;
            case PlayerStateEnum.ICE: playerState = PlayerStateEnum.STEAM; break;
            case PlayerStateEnum.STEAM: playerState = PlayerStateEnum.LIQUID; break;
            default: SendMessage("存在しないプレイヤーの状態です"); break;
        }

        // 新しい状態のコンポーネントへ切り替える
        ChangeFoamComponent();

        //新しいBodyを生成
        ChangeBody();
    }

    //前の状態のコンポーネントを外し、新しいコンポーネントをセットする
    void ChangeFoamComponent()
    {
        switch (playerState)
        {
            case PlayerStateEnum.LIQUID : break;
            case PlayerStateEnum.ICE    : this.gameObject.AddComponent<G_Player>(); break;
            case PlayerStateEnum.STEAM  : Destroy(this.GetComponent<G_Player>()); break;
            default: SendMessage("存在しないプレイヤーの状態です"); break;
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
            case PlayerStateEnum.LIQUID : Instantiate(icePref, this.transform); break;
            case PlayerStateEnum.ICE    : Instantiate(steamPref, this.transform); break;
            case PlayerStateEnum.STEAM  : Instantiate(liquidPref, this.transform); break;
            default: SendMessage("存在しないプレイヤーの状態です"); break;
        }
    }
}

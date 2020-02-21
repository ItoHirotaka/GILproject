using UnityEngine;

public enum PlayerStateEnum
{
    LIQUID = 0,
    ICE,
    STEAM,
};

[RequireComponent(typeof(Rigidbody))] // Rigidbody追加
[RequireComponent(typeof(Collider))]  // Collider追加
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

    [SerializeField]
    GameObject liquidPref;
    [SerializeField]
    GameObject icePref;
    [SerializeField]
    GameObject steamPref;

    void Start()
    { 
        // コンポーネントの取得
        rb = GetComponent<Rigidbody>();
        // Bodyを生成
        playerState = PlayerStateEnum.LIQUID;
        CreateNewBody();
    }

    void Update()
    {
        // 移動処理
        Move();

        // 状態変更
        ChangeState();
    }

    void Move()
    {
        Vector3 force = new Vector3(thrust, 0.0f, 0.0f);
        // 左に移動
        if (Input.GetKey(KeyCode.A) && rb.velocity.magnitude < MaxPow)
        {
            rb.AddForce(-force); // 力を加える
        }
        // 右に移動
        if (Input.GetKey(KeyCode.D) && rb.velocity.magnitude < MaxPow)
        {
            rb.AddForce(force); // 力を加える
        }
    }

    void ChangeState()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            // 状態の変更
            switch (playerState)
            {
                case PlayerStateEnum.LIQUID: playerState = PlayerStateEnum.ICE; break;
                case PlayerStateEnum.ICE: playerState = PlayerStateEnum.STEAM; break;
                case PlayerStateEnum.STEAM: playerState = PlayerStateEnum.LIQUID; break;
                default: SendMessage("存在しないプレイヤーの状態です"); break;
            }

            // 新しい子オブジェクトを生成
            CreateNewBody();
        }
    }

    //現在の状態を見て、新しいBodyを生成する
    void CreateNewBody()
    {
        // 現在のBodyを破壊
        foreach (Transform c in this.transform)
        {
            GameObject.Destroy(c.gameObject);
        }

        // 新しいBodyを生成
        GameObject obj = null;
        switch (playerState)    // 生成するBodyを決定
        {
            case PlayerStateEnum.LIQUID : obj = icePref     ; break;
            case PlayerStateEnum.ICE    : obj = steamPref   ; break;
            case PlayerStateEnum.STEAM  : obj = liquidPref  ; break;
        }
        if (obj == null) // 生成するBodyが無い場合終了する
        {
            SendMessage("Bodyの生成に失敗しました");
            return;
        }
        Instantiate(obj, this.transform);

        // 生成したBodyを子に設定
        obj.transform.SetParent(this.transform);
    }
}

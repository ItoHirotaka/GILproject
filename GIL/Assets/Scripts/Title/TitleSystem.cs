using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleSystem : MonoBehaviour
{
    [SerializeField]
    GameObject FadeImage = null;
    FadeUi fadeUi;
    // Start is called before the first frame update
    void Start()
    {
        // コンポーネントの取得
        fadeUi = FadeImage.GetComponent<FadeUi>();
        // フェードアウト
        fadeUi.ChangeState(FadeUi.FadeState.FadeOut);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

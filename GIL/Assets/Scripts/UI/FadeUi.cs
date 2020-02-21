using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeUi : MonoBehaviour
{
    public enum FadeState
    {
        Normal = 0,
        FadeIn,
        FadeOut
    }
    [SerializeField]
    FadeState state = FadeState.Normal;
  
    [SerializeField]
    Image image = null;
    [SerializeField]
    float fadeSpeed = 0.02f;

    float red, green, blue, alpha;


    // Start is called before the first frame update
    void Start()
    {
        //元の色を取得
        red = image.color.r;
        green = image.color.g;
        blue = image.color.b;
        alpha = image.color.a;
    }

    

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case FadeState.Normal   : break;
            case FadeState.FadeIn   : FadeIn(); break;
            case FadeState.FadeOut  : FadeOut(); break;
            default                 : SendMessage("FadeStateで問題が発生しています"); break;
        }
    }

    public void ChangeState(FadeState _state)
    {
        if (state != _state)
        {
            state = _state;
        }
    }

    float MaxAlpha = 1f;
    //フェードイン
    void FadeIn()
    {
        if (alpha < MaxAlpha)
        {
            alpha += fadeSpeed;
            if (alpha > MaxAlpha)
            {
                alpha = MaxAlpha;
                ChangeState(FadeState.Normal);
            }
            SetAlpha();
        }
    }

    float MinAlpha = 0f;
    //フェードアウト
    void FadeOut()
    {
        if (alpha > MinAlpha)
        {
            alpha -= fadeSpeed;
            if (alpha < MinAlpha)
            {
                alpha = MinAlpha;
                ChangeState(FadeState.Normal);
            }
            SetAlpha();
        }
    }

    //透明度を変更
    void SetAlpha()
    {
        image.color = new Color(red, green, blue, alpha);
    }
}

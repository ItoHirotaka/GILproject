using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeUi : MonoBehaviour
{
    [SerializeField]
    bool fade=false;
  
    [SerializeField]
    Image image=null;
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
        if (fade)
        {
          FadeIn();
        }
        else
        {
            FadeOut();
        }
       
    }

    //フェードイン
    void FadeIn()
    {
        alpha += fadeSpeed;
        SetAlpha();
       
    }
    //フェードアウト
    void FadeOut()
    {
        alpha -= fadeSpeed;
        SetAlpha();
       
    }
    //透明度を変更
    void SetAlpha()
    {
        image.color = new Color(red, green, blue, alpha);
    }
}

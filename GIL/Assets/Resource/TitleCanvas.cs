using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleCanvas : MonoBehaviour
{
    [SerializeField]
    int StageMax; //ステージの数によって切り替えてね。

    int currentNum;

    //イメージの取得
    Image image;
    Sprite sprite;

    SpriteRenderer MainSpriteRenderer;
    public Sprite[] sprites;

    private void Start()
    {
        StageMax = 3; //仮置きで3にしておきます。
        if (PlayerPrefs.HasKey("StageNum"))
        {
            currentNum = PlayerPrefs.GetInt("StageNum");
        }
        else
        {
            currentNum = 0;
        }

        // このobjectのSpriteRendererを取得
        MainSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) && currentNum > 0) 
        {
            currentNum -= 1;
            Change();
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) && currentNum < StageMax)
        {
            currentNum += 1;
            Change();
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            PlayerPrefs.SetInt("StageNum", currentNum);
            SceneManager.LoadScene("GameMain2D");
        }
        Change();
    }

    private void Change()
    {
        // SpriteRenderのspriteを設定済みの他のspriteに変更
        // 例) HoldSpriteに変更
        MainSpriteRenderer.sprite = sprites[currentNum];
        //if (currentNum == 0)
        //{
        //    // SpriteRenderのspriteを設定済みの他のspriteに変更
        //    // 例) HoldSpriteに変更
        //    MainSpriteRenderer.sprite = HoldSprite;
        //    Debug.Log("１：呼ばれた");
        //}
        //if (currentNum == 1)
        //{
        //    sprite = Resources.Load<Sprite>("Resources/Title_02");
        //    image = this.GetComponent<Image>();
        //    image.sprite = sprite;
        //    Debug.Log("２：呼ばれた");
        //}
        //if (currentNum == 2)
        //{
        //    sprite = Resources.Load<Sprite>("Title_03");
        //    image = this.GetComponent<Image>();
        //    image.sprite = sprite;
        //    Debug.Log("３：呼ばれた");
        //}
        //if (currentNum == 3)
        //{
        //    sprite = Resources.Load<Sprite>("Title_04");
        //    image = this.GetComponent<Image>();
        //    image.sprite = sprite;
        //    Debug.Log("４：呼ばれた");
        //}
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleCanvas : MonoBehaviour
{
    [SerializeField]
    TitleSystem system;

    [SerializeField]
    int StageMax; //ステージの数によって切り替えてね。

    public GameObject[] TitleImage;
    public int currentNum { get; private set; }

    private void Start()
    {
        // コンポーネントの取得
        system = this.GetComponent<TitleSystem>();
        if (PlayerPrefs.HasKey("StageNum"))
        {
            currentNum = PlayerPrefs.GetInt("StageNum");
        }
        else
        {
            currentNum = 0;
        }

        // 初期の画像をセット
        Change();
    }
    void Update()
    {
        TitleInpuut();
    }

    private void TitleInpuut()
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

        }
    }

    private void Change()
    {
        // SpriteRenderのspriteを設定済みの他のspriteに変更
        // 例) HoldSpriteに変更
        //MainSpriteRenderer.sprite = sprites[currentNum];
        if (currentNum == 0)
        {
            TitleImage[0].SetActive(true);
            TitleImage[1].SetActive(false);
            TitleImage[2].SetActive(false);
            TitleImage[3].SetActive(false);
            Debug.Log("１：呼ばれた");
        }
        if (currentNum == 1)
        {
            TitleImage[0].SetActive(false);
            TitleImage[1].SetActive(true);
            TitleImage[2].SetActive(false);
            TitleImage[3].SetActive(false);
            Debug.Log("２：呼ばれた");
        }
        if (currentNum == 2)
        {
            TitleImage[0].SetActive(false);
            TitleImage[1].SetActive(false);
            TitleImage[2].SetActive(true);
            TitleImage[3].SetActive(false);
            Debug.Log("３：呼ばれた");
        }
        if (currentNum == 3)
        {
            TitleImage[0].SetActive(false);
            TitleImage[1].SetActive(false);
            TitleImage[2].SetActive(false);
            TitleImage[3].SetActive(true);
            Debug.Log("４：呼ばれた");
        }
    }


}

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

    public GameObject[] TitleImage;

    //イメージの取得
    //Image image;
    //Sprite sprite;

    //SpriteRenderer MainSpriteRenderer;
    //public Sprite[] sprites;

    private void Start()
    {
        //TitleImage[0] = transform.Find("Resource/Title_01").gameObject;
        //TitleImage[1] = transform.Find("Resource/Title_02").gameObject;
        //TitleImage[2] = transform.Find("Resource/Title_03").gameObject;
        //TitleImage[3] = transform.Find("Resource/Title_04").gameObject;

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
        //MainSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
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

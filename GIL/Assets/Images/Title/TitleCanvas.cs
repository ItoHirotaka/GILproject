using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleCanvas : MonoBehaviour
{
    [SerializeField]
    GameObject[] TitleImage;

    int currentNum;

    private void Start()
    {
        if (PlayerPrefs.HasKey("StageNum"))
        {
            currentNum = PlayerPrefs.GetInt("StageNum");
        }
        else
        {
            currentNum = 0;
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            currentNum -= 1;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            currentNum += 1;
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            PlayerPrefs.SetInt("StageNum", currentNum);
            SceneManager.LoadScene("GameMain2D");
        }
    }

    private void Change()
    {
        
    }
}

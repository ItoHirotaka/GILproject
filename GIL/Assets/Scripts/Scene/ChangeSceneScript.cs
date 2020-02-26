using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneScript : MonoBehaviour
{
    public enum SceneType
    {
        Title = 0,
        GameMain
    }
    [SerializeField]
    SceneType changeType;

    public void ChangeScene()
    {
        switch (changeType)
        {
            case SceneType.Title: SceneManager.LoadScene("Title"); break;
            case SceneType.GameMain: SceneManager.LoadScene("GameMain2D"); break;
        }
    }
}

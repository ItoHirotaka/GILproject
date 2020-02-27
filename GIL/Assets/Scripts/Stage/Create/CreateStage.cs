using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateStage : MonoBehaviour
{
    [SerializeField]
    GameObject[] Stages;
    // Start is called before the first frame update
    void Awake()
    {
        Create();
    }

    void Create()
    {
        int stageNum = PlayerPrefs.GetInt("StageNum");
        GameObject obj = Instantiate(Stages[stageNum]);
    }
}

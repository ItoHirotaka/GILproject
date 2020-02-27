using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    private static GameObject mInstance;

    public static GameObject Instance
    {
        get
        {
            return mInstance;
        }
    }

    void Awake()
    {
        if (mInstance == null)
        {
            DontDestroyOnLoad(gameObject);
            mInstance = gameObject;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}

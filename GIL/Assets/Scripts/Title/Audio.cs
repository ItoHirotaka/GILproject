using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    [SerializeField]
    AudioClip bgm;
    // Start is called before the first frame update
    void Start()
    {
        // BGMを再生
        AudioSource.PlayClipAtPoint(bgm, this.gameObject.transform.position);
        // このオブジェクトを破壊しないようにする
        DontDestroyOnLoad(this.gameObject);
    }
}

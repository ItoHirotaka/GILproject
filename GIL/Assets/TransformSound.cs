using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformSound : MonoBehaviour
{
    [SerializeField]
    AudioClip audio;

    public void PlaySound()
    {
        AudioSource.PlayClipAtPoint(audio, this.transform.position);
    }
}

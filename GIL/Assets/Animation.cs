using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    // アニメーション用
    Animator animator;
    string walkStr = "isWalk";
    string groundedStr = "isGrounded";

    // 着地判定時に呼ぶ
    public void Ground()
    {
        // アニメーション
        animator.SetBool(groundedStr, true);
    }
}

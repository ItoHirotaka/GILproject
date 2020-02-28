using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    GameObject Player = null;
    PlayerController2D controller = null;

    // アニメーション用
    Animator animator;
    string walkStr = "isWalk";
    string groundedStr = "isGrounded";

    private void Start()
    {
        Player = GameObject.Find("Player");
        controller = Player.GetComponent<PlayerController2D>();
        animator = this.GetComponent<Animator>();
    }

    private void Update()
    {
        animator.SetBool(walkStr, controller.IsMove);
    }
    // 着地判定時に呼ぶ
    public void Ground()
    {
        // アニメーション
        animator.SetBool(groundedStr, true);
    }
}

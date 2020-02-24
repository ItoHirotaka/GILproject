using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataProvider2D : MonoBehaviour
{
    [SerializeField] private PlayerController2D playerController = null;

    public PlayerStateEnum2D IsPlayerStateEnum { get { return playerController.playerState; } }//自機の状態


    // Update is called once per frame
    void Update()
    {

    }
}

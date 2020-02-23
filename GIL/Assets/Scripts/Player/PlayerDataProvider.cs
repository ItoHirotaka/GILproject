using UnityEngine;

public class PlayerDataProvider : MonoBehaviour
{
    [SerializeField] private PlayerController playerController = null;

    public PlayerStateEnum IsPlayerStateEnum { get { return playerController.playerState; } }//自機の状態


    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementlCanvas : MonoBehaviour
{
    [SerializeField]
    GameObject LiquidImage;

    [SerializeField]
    GameObject GasImage;

    [SerializeField]
    GameObject IceImage;

    public void ChangeImage(PlayerStateEnum2D _state)
    {
        if (_state == PlayerStateEnum2D.LIQUID)
        {
            LiquidImage.SetActive(true);
            GasImage.SetActive(false);
            IceImage.SetActive(false);
        }
        if (_state == PlayerStateEnum2D.STEAM)
        {
            LiquidImage.SetActive(false);
            GasImage.SetActive(true);
            IceImage.SetActive(false);
        }
        if (_state == PlayerStateEnum2D.ICE)
        {
            LiquidImage.SetActive(false);
            GasImage.SetActive(false);
            IceImage.SetActive(true);
        }
    }
}

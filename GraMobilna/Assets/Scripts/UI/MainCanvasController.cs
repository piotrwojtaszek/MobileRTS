using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainCanvasController : MonoBehaviour
{
    [SerializeField]
    Image BTN_BuildMode;
    [SerializeField]
    Image BTN_MoveMode;
    [SerializeField]
    Image BTN_InteractMode;

    private void Update()
    {
        if(GameControllerScript.Instance.GetBuildMode())
        {
            BTN_BuildMode.color = Color.black;
        }
        else
        {
            BTN_BuildMode.color = Color.white;
        }
        if (GameControllerScript.Instance.GetMoveMode())
        {
            BTN_MoveMode.color = Color.black;
        }
        else
        {
            BTN_MoveMode.color = Color.white;
        }
        if (GameControllerScript.Instance.GetInteractionMode())
        {
            BTN_InteractMode.color = Color.black;
        }
        else
        {
            BTN_InteractMode.color = Color.white;
        }
    }

    public void BuildModeSwitch()
    {
        GameControllerScript.Instance.currentGridPoint = null;
        Debug.Log("Zmien tryb");
        GameControllerScript.Instance.SetBuildMode(!GameControllerScript.Instance.GetBuildMode());
    }
    public void MoveModeSwitch()
    {
        GameControllerScript.Instance.SetMoveMode(!GameControllerScript.Instance.GetMoveMode());
    }

    public void InteractionModeSwitch()
    {
        GameControllerScript.Instance.SetInteractionMode(!GameControllerScript.Instance.GetInteractionMode());
    }
}

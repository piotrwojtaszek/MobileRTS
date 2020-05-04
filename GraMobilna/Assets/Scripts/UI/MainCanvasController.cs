using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCanvasController : MonoBehaviour
{
    [SerializeField]
    GameObject BTN_BuildMode;

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

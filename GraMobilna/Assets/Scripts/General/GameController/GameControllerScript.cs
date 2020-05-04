using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerScript : MonoBehaviour
{
    public static GameControllerScript Instance;
    public GridPoint currentGridPoint;
    public BuildingStats currentBuilding;
    private bool interactionMode=false;
    private bool buildMode=false;
    private bool moveMode = true;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        
    }

    public void SetRayFromCamera(bool value)
    {
        interactionMode = value;
    }

    public bool GetRayFromCamera()
    {
        return interactionMode;
    }
    public void SetBuildMode(bool value)
    {
        buildMode = value;
    }

    public bool GetBuildMode()
    {
        return buildMode;
    }

    public void SetMoveMode(bool value)
    {
        moveMode = value;
    }

    public bool GetMoveMode()
    {
        return moveMode;
    }
    public void SetInteractionMode(bool value)
    {
        interactionMode = value;
    }

    public bool GetInteractionMode()
    {
        return interactionMode;
    }
}

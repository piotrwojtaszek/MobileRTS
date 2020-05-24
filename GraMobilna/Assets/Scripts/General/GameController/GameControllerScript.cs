using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerScript : MonoBehaviour
{
    public static GameControllerScript Instance;
    public GridPoint currentGridPoint;
    public BuildingStats currentBuilding;
    private bool interactionMode = false;
    private bool buildMode = false;
    private bool moveMode = true;
    public int drewnoIncrece = 0;
    int kamienIncrece = 0;
    int wegielIncrece = 0;
    int metalIncrece = 0;
    public int drewnoAmount = 0;
    public int kamienAmount = 0;
    public int wegielAmount = 0;
    public int metalAmount = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        StartCoroutine(Collect());
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

IEnumerator Collect()
    {
        for(; ;)
        {
            Debug.Log("Trees nerby: " + drewnoIncrece + " Drewno amount: " + drewnoAmount);
            drewnoAmount += drewnoIncrece;
            yield return new WaitForSeconds(10f);
        }
    }
}

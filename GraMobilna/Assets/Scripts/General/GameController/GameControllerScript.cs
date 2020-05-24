using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.PlayerLoop;

public class GameControllerScript : MonoBehaviour
{
    public static GameControllerScript Instance;
    public GridPoint currentGridPoint;
    public BuildingStats currentBuilding;
    public UnityAction zasobyTimer;
    private bool interactionMode = false;
    private bool buildMode = false;
    private bool moveMode = true;
    public int drewnoIncrece = 0;
    public int kamienIncrece = 0;
    public int wegielIncrece = 0;
    public int metalIncrece = 0;
    public int drewnoAmount = 0;
    public int kamienAmount = 0;
    public int wegielAmount = 0;
    public int metalAmount = 0;
    public float collectTimer = 0;
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

    private void Update()
    {
        collectTimer += Time.deltaTime;
    }

    IEnumerator Collect()
    {
        for (; ; )
        {
            drewnoAmount += drewnoIncrece;
            kamienAmount += kamienIncrece;
            wegielAmount += wegielIncrece;
            metalAmount += metalIncrece;
            collectTimer = 0f;
            yield return new WaitForSeconds(10f);
        }
    }
}

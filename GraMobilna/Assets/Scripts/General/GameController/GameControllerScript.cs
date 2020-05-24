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
    private bool interactionMode = false;
    private bool buildMode = false;
    private bool moveMode = true;

    // Szybkość przyrostu zasobów
    [HideInInspector]
    public int drewnoIncrece = 0;
    [HideInInspector]
    public int kamienIncrece = 0;
    [HideInInspector]
    public int wegielIncrece = 0;
    [HideInInspector]
    public int metalIncrece = 0;

    // Ilość aktualnie posiadanych zasobów
    public int drewnoAmount = 150;
    public int kamienAmount = 100;
    public int wegielAmount = 50;
    public int metalAmount = 50;

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
            // to ma być wywolywane w kazdym budynku!!
            drewnoAmount += drewnoIncrece;
            kamienAmount += kamienIncrece;
            wegielAmount += wegielIncrece;
            metalAmount += metalIncrece;
            collectTimer = 0f;
            yield return new WaitForSeconds(10f);
        }
    }
}

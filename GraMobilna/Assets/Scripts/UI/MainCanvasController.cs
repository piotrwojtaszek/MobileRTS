using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCanvasController : MonoBehaviour
{
    EventsOnMapScript mapScript;
    EventsOnMapScript ray;
    private void Awake()
    {
        mapScript = Resources.Load("Prefabs/ScriptableObjects/Events/BuildMode") as EventsOnMapScript;
        ray = Resources.Load("Prefabs/ScriptableObjects/Events/RayFromCamera") as EventsOnMapScript;
        ray.Value = true;
    }

    public void SwitchMode()
    {
        Debug.Log("Zmien tryb");
        mapScript.Value = !mapScript.Value;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCanvasController : MonoBehaviour
{
    EventsOnMapScript mapScript;
    EventsOnMapScript ray;
    [SerializeField]
    GameObject BTN_BuildMode;
    private void Awake()
    {
        mapScript = Resources.Load("Prefabs/ScriptableObjects/Events/BuildMode") as EventsOnMapScript;
        ray = Resources.Load("Prefabs/ScriptableObjects/Events/RayFromCamera") as EventsOnMapScript;
        ray.Value = true;
    }

    private void Update()
    {
        BTN_BuildMode.SetActive(ray.Value);
    }

    public void SwitchMode()
    {
        GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControllerScript>().currentGridPoint = null;
           Debug.Log("Zmien tryb");
        mapScript.Value = !mapScript.Value;
    }
}

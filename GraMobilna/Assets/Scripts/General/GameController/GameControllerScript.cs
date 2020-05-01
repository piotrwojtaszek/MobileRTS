using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerScript : MonoBehaviour
{
    EventsOnMapScript mapScript;
    public GridPoint currentGridPoint;
    private void Awake()
    {
        mapScript = Resources.Load("Prefabs/ScriptableObjects/Events/BuildMode") as EventsOnMapScript;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            mapScript.Value = !mapScript.Value;

        }
    }
}

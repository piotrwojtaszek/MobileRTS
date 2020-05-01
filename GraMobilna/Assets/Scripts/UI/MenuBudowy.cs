using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBudowy : MonoBehaviour
{
    EventsOnMapScript ray;
    public void CloseUI()
    {
        Destroy(this.gameObject);
        ray = Resources.Load("Prefabs/ScriptableObjects/Events/RayFromCamera") as EventsOnMapScript;
        ray.Value = true;

    }
}

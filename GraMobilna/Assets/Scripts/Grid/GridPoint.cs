using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridPoint : Interactable
{
    [SerializeField]
    private GameObject model;
    public GameObject budynek;
    public bool empty = true;

    public override void Interact()
    {
        base.Interact();
        if(empty)
        {
            BuildingsPresets buildingMenu = Resources.Load("Prefabs/ScriptableObjects/ElementyUI") as BuildingsPresets;
            EventsOnMapScript ray= Resources.Load("Prefabs/ScriptableObjects/Events/RayFromCamera") as EventsOnMapScript;
            GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControllerScript>().currentGridPoint = GetComponent<GridPoint>();
            Instantiate(buildingMenu.budynki[0]);
            ray.Value = false;
        }
        model.GetComponent<Renderer>().material = Resources.Load("Prefabs/Materials/Touched") as Material;
    }

    public void SwitchMode(bool mode)
    {
        if(mode)
        {
            if (empty)
            {
                GameObject temp = Resources.Load("Prefabs/Grid/GridPointModel") as GameObject;
                model = Instantiate(temp, transform);
            }
        }
        else
        {
            if(empty)
            {
                Destroy(model);
            }
        }
    }

    public void DodajBudynek(GameObject doWczytania)
    {
        Instantiate(doWczytania, transform);
        empty = false;
    }
}

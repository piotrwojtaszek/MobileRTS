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
            GameControllerScript.Instance.currentGridPoint = this;
            Instantiate(buildingMenu.budynki[0]);
            GameControllerScript.Instance.SetRayFromCamera(false);
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
                GetComponent<Collider>().enabled = true;
            }
        }
        else
        {
            if(empty)
            {
                GetComponent<Collider>().enabled = false;
                Destroy(model);
            }
        }
    }

    public void DodajBudynek(GameObject doWczytania)
    {
        Destroy(model);
        GameObject obiekt = Instantiate(doWczytania, transform);
        empty = false;
    }
}

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
            BuildingsPresets temp = Resources.Load("Prefabs/ScriptableObjects/ElementyUI") as BuildingsPresets;
            Instantiate(temp.budynki[0]);
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

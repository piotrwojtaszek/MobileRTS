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

    public void DodajBudynek()
    {
        GameObject temp = Resources.Load("Prefabs/Objects/Buildings/Prefabs/Drzewo") as GameObject;
        Instantiate(temp, transform);
        empty = false;
    }
}

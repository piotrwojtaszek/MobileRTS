using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridPoint : Interactable
{
    [SerializeField]
    private GameObject model;

    private void Awake()
    {
        GameObject temp = Resources.Load("Prefabs/Grid/GridPointModel") as GameObject;
        model = Instantiate(temp, transform);
    }

    public override void Interact()
    {
        base.Interact();
        model.GetComponent<Renderer>().material = Resources.Load("Prefabs/Materials/Touched") as Material;
    }
}

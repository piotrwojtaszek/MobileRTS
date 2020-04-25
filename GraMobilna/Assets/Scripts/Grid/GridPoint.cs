using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridPoint : Interactable
{
    [SerializeField]
    private GameObject model;
    public AnimationCurve curve;
    private void Awake()
    {
        GameObject temp = Resources.Load("Prefabs/Grid/GridPointModel") as GameObject;
        model = Instantiate(temp, transform);
        PingPongAnimation.PingPongScale(gameObject,1.5f,.7f,curve);
    }

    public override void Interact()
    {
        base.Interact();
        model.GetComponent<Renderer>().material = Resources.Load("Prefabs/Materials/Touched") as Material;
    }
}

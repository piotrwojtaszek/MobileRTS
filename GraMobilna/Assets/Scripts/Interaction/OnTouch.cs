using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTouch : MonoBehaviour
{
    public void OnTouching()
    {
        gameObject.GetComponent<Renderer>().material = Resources.Load("Prefabs/Materials/Touched") as Material;
    }
}

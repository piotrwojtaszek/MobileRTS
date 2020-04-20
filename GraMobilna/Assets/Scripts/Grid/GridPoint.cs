using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridPoint : MonoBehaviour
{
    private bool empty = true;

    public void SimpleCube(Vector3 pos)
    {
        GameObject.CreatePrimitive(PrimitiveType.Sphere).transform.position = pos;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Budynek",menuName = "MyObjects/Budynki")]
public class BuildingsPresets : ScriptableObject
{
    public List<GameObject> budynki = new List<GameObject>();

    public void AddToList(GameObject obj)
    {
        budynki.Add(obj);
    }

    public void Die()
    {
        foreach(GameObject g in budynki)
        {
            Destroy(g);

        }
    }
}

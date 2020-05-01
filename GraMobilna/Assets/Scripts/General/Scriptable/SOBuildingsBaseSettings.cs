using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NowyBudynek",menuName ="MyObjects/NewBuilding")]
public class SOBuildingsBaseSettings : ScriptableObject
{
    public int maxHealth;
    public GameObject model;
    public int koszt;

}

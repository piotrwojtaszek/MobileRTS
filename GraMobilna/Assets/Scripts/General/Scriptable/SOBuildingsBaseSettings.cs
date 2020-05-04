using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NowyBudynek",menuName ="MyObjects/NewBuilding")]
public class SOBuildingsBaseSettings : ScriptableObject
{
    public Sprite icon;
    public float maxHealth;
    public string buildingName;
    public GameObject model;
    public int koszt;
    public int interactions=0;
}

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
    public int kosztDrewna;
    public int kosztKamienia;
    public int kosztWegla;
    public int kosztMetalu;
    public int interactions=0;
}

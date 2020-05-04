using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   
public class CardBuildingDisplay : MonoBehaviour
{
    
    public SOBuildingsBaseSettings settings;
    [SerializeField]
    private Image icon;
    public MenuBudowy parent;

    public void Start()
    {
        icon.sprite = settings.icon;
    }

    public void OnClick()
    {
        Debug.Log("Dodaj Budynek -> "+settings.buildingName);
        GameControllerScript.Instance.currentGridPoint.DodajBudynek(settings.model);
        GameControllerScript.Instance.currentGridPoint = null;
        parent.CloseUI();
        GameControllerScript.Instance.SetRayFromCamera(true);
    }

}

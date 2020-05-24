using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;   
public class CardBuildingDisplay : MonoBehaviour
{
    
    public SOBuildingsBaseSettings settings;
    [SerializeField]
    private Image icon;
    public MenuBudowy parent;
    [SerializeField]
    private TextMeshProUGUI buildingNameText;

    public void Start()
    {
        icon.sprite = settings.icon;
        buildingNameText.text = settings.buildingName;
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

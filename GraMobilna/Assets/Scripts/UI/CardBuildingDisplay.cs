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
    private bool ableToClick = false;
    public Image buttonAdd;
    public void Start()
    {
        icon.sprite = settings.icon;
        buildingNameText.text = settings.buildingName;
    }

    private void Update()
    {
        if (GameControllerScript.Instance.drewnoAmount >= settings.kosztDrewna && GameControllerScript.Instance.kamienAmount >= settings.kosztKamienia &&
            GameControllerScript.Instance.wegielAmount >= settings.kosztWegla && GameControllerScript.Instance.metalAmount >= settings.kosztMetalu)
        {
            ableToClick = true;
            buttonAdd.color = new Color(143f / 255f, 1f, 168f / 255f);
        }
        else
        {
            ableToClick = false;
            buttonAdd.color = new Color(120f / 255f, 120f / 255f, 120f / 255f);
        }

    }

    public void OnClick()
    {
        if (ableToClick)
        {
            Debug.Log("Dodaj Budynek -> " + settings.buildingName);
            GameControllerScript.Instance.currentGridPoint.DodajBudynek(settings.model);
            GameControllerScript.Instance.currentGridPoint = null;
            parent.CloseUI();
            GameControllerScript.Instance.SetRayFromCamera(true);
            GameControllerScript.Instance.drewnoAmount -= settings.kosztDrewna;
            GameControllerScript.Instance.kamienAmount -= settings.kosztKamienia;
            GameControllerScript.Instance.wegielAmount -= settings.kosztWegla;
            GameControllerScript.Instance.metalAmount -= settings.kosztMetalu;
        }
    }

}

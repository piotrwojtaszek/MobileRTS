using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MenuBudowy : MonoBehaviour
{
    [SerializeField]
    Scrollbar scroll;
    [SerializeField]
    GameObject content;
    BuildingsList listaBudunkow;
    GameObject builidingCardPrefab;
    bool oldMoveMode;
    private void Start()
    {
        oldMoveMode = GameControllerScript.Instance.GetMoveMode();
        GameControllerScript.Instance.SetMoveMode(false);
        listaBudunkow = Resources.Load("Prefabs/ScriptableObjects/Budynki/ListaBudynkow") as BuildingsList;
        foreach(SOBuildingsBaseSettings item in listaBudunkow.lista)
        {
            builidingCardPrefab = Resources.Load("Prefabs/UI/BUILDING/CardBuilding") as GameObject;
            GameObject builidingCard = Instantiate(builidingCardPrefab, content.transform);
            builidingCard.GetComponent<CardBuildingDisplay>().settings = item;
            builidingCard.GetComponent<CardBuildingDisplay>().parent = this.GetComponent<MenuBudowy>();
        }
        scroll.value = 0;
    }
    public void CloseUI()
    {
        Destroy(this.gameObject);
        GameControllerScript.Instance.SetRayFromCamera(true);
        GameControllerScript.Instance.SetBuildMode(false);
        GameControllerScript.Instance.SetMoveMode(oldMoveMode);

    }
}

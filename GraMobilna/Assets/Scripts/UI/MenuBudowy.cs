using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MenuBudowy : MonoBehaviour
{
    EventsOnMapScript ray;
    [SerializeField]
    Scrollbar scroll;
    [SerializeField]
    GameObject content;
    BuildingsList listaBudunkow;
    GameObject builidingCardPrefab;
    private void Start()
    {
       
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
        ray = Resources.Load("Prefabs/ScriptableObjects/Events/RayFromCamera") as EventsOnMapScript;
        ray.Value = true;

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MenuBuildInteractions : MonoBehaviour
{

    GameObject cardPrefab;
    int numberOfInteractions = 0;
    public GameObject interactionsContainer;
    public Slider healthBar;
    public BuildingStats currentBuilding;
    // Start is called before the first frame update
    void Start()
    {
        GameControllerScript.Instance.SetRayFromCamera(false);
        cardPrefab = Resources.Load("Prefabs/UI/BUILDING/CardBuildingInteraction") as GameObject;


    }

    private void Update()
    {
        if (currentBuilding != GameControllerScript.Instance.currentBuilding)
            Load();
    }

    void LateUpdate()
    {
        if (currentBuilding != null)
            healthBar.value = currentBuilding.currentHealth / currentBuilding.maxHealth;
    }

    public void Load()
    {
        currentBuilding = GameControllerScript.Instance.currentBuilding;
        numberOfInteractions = currentBuilding.settings.interactions;

        for (int i = 0; i < numberOfInteractions; i++)
        {
            GameObject card = Instantiate(cardPrefab, interactionsContainer.transform);
            card.GetComponent<CardBuildInterDisplay>().id = i;
        }
    }

    public void CloseUI()
    {
        GameControllerScript.Instance.SetRayFromCamera(true);
        GameControllerScript.Instance.currentBuilding = null;
        Destroy(gameObject);
    }
}

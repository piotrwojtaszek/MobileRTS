using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class CardBuildInterDisplay : MonoBehaviour,IPointerClickHandler
{
    public int id;

    public void OnPointerClick(PointerEventData eventData)
    {
        GameControllerScript.Instance.currentBuilding.InteractionCard(id);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainBaseController : BuildingStats
{
    public override void Interact()
    {
        /*Debug.Log("MainBase");
        TakeDamage(20f);
        if (currentHealth <= 0)
        {
            Die();
        }*/
        GameControllerScript.Instance.currentBuilding = this;
        base.InteractionCard(0);
    }

    public override void InteractionCard(int number)
    {
        if(number==0)
        {
            Debug.Log("Interakcja numer 0");
        }
        if(number == 1)
        {
            Debug.Log("Interakcja numer 1");
        }
    }
}

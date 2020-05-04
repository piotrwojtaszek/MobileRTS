using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TartakController : BuildingStats
{
    public override void Interact()
    {
        /*Debug.Log("Tartak");
        TakeDamage(20f);
        if(currentHealth <=0)
        {
            Die();
        }*/
        GameControllerScript.Instance.currentBuilding = this;
        base.InteractionCard(0);
    }

    public override void InteractionCard(int number)
    {
        
        if (number == 0)
        {
            Debug.Log("Interakcja numer 0 tartak");
        }
        if (number == 1)
        {
            Debug.Log("Interakcja numer 1 tartak");
        }
    }
}

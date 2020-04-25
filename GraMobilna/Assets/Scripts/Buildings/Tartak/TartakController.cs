using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TartakController : BuildingStats
{
    public override void Interact()
    {
        Debug.Log("Tartak");
        TakeDamage(20f);
        if(currentHealth <=0)
        {
            Die();
        }
    }
}

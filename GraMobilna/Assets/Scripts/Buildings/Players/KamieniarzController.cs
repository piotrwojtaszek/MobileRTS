﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KamieniarzController : BuildingStats
{
    int layerMask = 1 << 14;
    public float radius = 1f;
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
            Debug.Log("Interakcja numer 0 kamieniarz");
        }
        if (number == 1)
        {
            Debug.Log("Interakcja numer 1 kamieniarz");
        }
    }

    public override void Collect()
    {
        Collider[] trees = Physics.OverlapSphere(transform.position, radius, layerMask);
        foreach (Collider c in trees)
        {
            GameControllerScript.Instance.kamienIncrece += 1;
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}

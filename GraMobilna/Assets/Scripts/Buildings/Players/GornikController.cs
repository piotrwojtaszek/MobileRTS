﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GornikController : BuildingStats
{
    int layerMask = 1 << 15;
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

        if (number == 0 && GameControllerScript.Instance.CheckIfEnoughMinerals(settings.kosztDrewna, settings.kosztKamienia, settings.kosztWegla, settings.kosztMetalu))
        {
            GameControllerScript.Instance.SubstractMinerals(settings.kosztDrewna, settings.kosztKamienia, settings.kosztWegla, settings.kosztMetalu);
            Collect();
            Debug.Log("Ulepszenie");
        }
    }

    public override void Collect()
    {
        Collider[] trees = Physics.OverlapSphere(transform.position, radius, layerMask);
        foreach (Collider c in trees)
        {
            GameControllerScript.Instance.wegielIncrece += 1;
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}

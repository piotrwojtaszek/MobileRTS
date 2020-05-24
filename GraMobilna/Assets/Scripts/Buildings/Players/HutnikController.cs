using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HutnikController : BuildingStats
{
    int layerMask = 1 << 16;
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
            Debug.Log("Interakcja numer 0 hutnik");
        }
        if (number == 1)
        {
            Debug.Log("Interakcja numer 1 hutnik");
        }
    }

    public override void Collect()
    {
        Collider[] trees = Physics.OverlapSphere(transform.position, radius, layerMask);
        foreach (Collider c in trees)
        {
            GameControllerScript.Instance.metalIncrece += 1;
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}

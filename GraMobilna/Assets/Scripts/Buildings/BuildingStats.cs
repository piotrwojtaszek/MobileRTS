using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingStats : Interactable, IBaseSettings
{
    public float currentHealth = 80f;
    public float maxHealth;
    public SOBuildingsBaseSettings settings;
    public GridPoint parent;

    public void Awake()
    {
        parent = GameControllerScript.Instance.currentGridPoint;
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);

    }
    public void Start()
    {
        SetMaxHealth(settings.maxHealth);
        Collect();

    }
    public void Create()
    {
        Debug.Log("Create");
    }

    public void SetMaxHealth(float _maxHealth)
    {
        maxHealth = _maxHealth;
        currentHealth = maxHealth;
    }

    public void Die()
    {

        Destroy(gameObject);
        parent.empty = true;
        Debug.Log("Zniszcz");
    }

    public override void Interact()
    {
        //modelGraficzny.GetComponent<Renderer>().material = Resources.Load("Prefabs/Materials/Touched") as Material;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
    }

    public void TakeHealth(float health)
    {
        currentHealth += health;
    }

    public virtual void InteractionCard(int number)
    {
        GameObject prefab = Resources.Load("Prefabs/UI/OnMapEvents/UIMenuIntrakcjiBudynkow") as GameObject;
        Instantiate(prefab);
    }

    public virtual void Collect()
    {
        //Debug.Log();
    }
}

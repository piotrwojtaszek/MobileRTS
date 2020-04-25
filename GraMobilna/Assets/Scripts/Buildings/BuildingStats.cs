using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingStats : Interactable, IBaseSettings
{
    public float currentHealth = 80f;
    public float maxHealth = 100f;
    public GameObject modelGraficzny;
    public void Awake()
    {
        transform.position = new Vector3((int)transform.position.x, transform.position.y, (int)transform.position.z);
    }
    public void Start()
    {
        SetMaxHealth(maxHealth);   
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
        Debug.Log("Zniszcz");
    }
    public override void Interact()
    {
        modelGraficzny.GetComponent<Renderer>().material = Resources.Load("Prefabs/Materials/Touched") as Material;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
    }

    public void TakeHealth(float health)
    {
        currentHealth += health;
    }
}

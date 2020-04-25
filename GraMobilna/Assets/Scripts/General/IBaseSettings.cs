using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBaseSettings 
{
    void Create();
    void Die();
    void TakeDamage(float damage);
    void TakeHealth(float health);

}

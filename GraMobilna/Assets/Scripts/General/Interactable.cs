﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
   public virtual void Interact()
    {
        
        Debug.Log("Nastapila interakcja z "+transform.name);
    }
}

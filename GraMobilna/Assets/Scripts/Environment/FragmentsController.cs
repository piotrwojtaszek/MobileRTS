﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FragmentsController : MonoBehaviour
{
    public GameObject m_prefab;

    private void Start()
    {
        int id = 0;
        for (float i = -17f; i <= 17f; i += 8.5f)
        {
            for (float j = -17; j <= 17; j += 8.5f)
            {
                GameObject temp = Instantiate(m_prefab, transform);
                temp.transform.position += new Vector3(i, 0, j);
                GridController con = temp.GetComponentInChildren<GridController>();
                con.id = id;

                id++;//12 srodkowy
            }
        }
    }
}

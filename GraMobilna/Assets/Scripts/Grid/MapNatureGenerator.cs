using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapNatureGenerator : MonoBehaviour
{

    public GameObject[] m_prefabs;

    public void Nature(int size, Transform parent, Vector3 position)
    {
        int amount = Random.Range(3, 6);



        for (int i = 0; i < amount; i++)
        {
            int losulosu = Random.Range(0, m_prefabs.Length);
            GameObject temp = Instantiate(m_prefabs[losulosu], parent);
            Vector2 sphere = Random.insideUnitCircle * 1f;
            temp.transform.localPosition = position+new Vector3(sphere.x,0f,sphere.y);
        }
    }
}

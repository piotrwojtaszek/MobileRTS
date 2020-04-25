using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridController : MonoBehaviour
{
    [SerializeField]
    private int size = 1;
    private GameObject gridPointPrefab;
    private GameObject gridBasePrefab;
    private void Awake()
    {
        gridPointPrefab = Resources.Load("Prefabs/Grid/GridPoint") as GameObject;
        gridBasePrefab = Resources.Load("Prefabs/Objects/Odlamki/Prefabs/baseGrid") as GameObject;
        GameObject ground = Instantiate(gridBasePrefab, transform);

        ground.transform.localScale = ground.transform.localScale * size;

        CreateGrid(size);
    }

    private void CreateGrid(int size)
    {
        for (int x = 0; x <= size; x++)
        {
            for (int z = 0; z <= size; z++)
            {
                Vector3 point = new Vector3(x, 0f, z);
                GameObject temp = Instantiate(gridPointPrefab,transform);
                temp.transform.position = point;
            }
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        for (int x = 0; x<size;x++)
        {
            for(int z = 0; z<size; z++)
            {
                Vector3 point = new Vector3(x, 0f, z);
                Gizmos.DrawSphere(point, 0.1f);
            }
        }
    }
}

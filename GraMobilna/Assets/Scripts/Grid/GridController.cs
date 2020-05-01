using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridController : MonoBehaviour
{
    [SerializeField]
    private int size = 1;
    private GameObject gridPrefab;
    private GameObject gridBasePrefab;
    public GameObject gridConteiner;
    public GameObject groundConteriner;
    private EventsOnMapScript mapScript;
    private BuildingsPresets neutralBuilidings;
    private List<GameObject> gridPoints = new List<GameObject>();
    private bool buildMode = false;

    private int treeNumber;
    private int rockNumber;
    private int coalNumber;
    private int metalNumber;
    private int uselessNumber;

    private void Start()
    {
        size = Random.Range(6, 9);
        gridPrefab = Resources.Load("Prefabs/Grid/GridPoint") as GameObject;
        gridBasePrefab = Resources.Load("Prefabs/Objects/Odlamki/Prefabs/baseGrid") as GameObject;

        GameObject ground = Instantiate(gridBasePrefab, groundConteriner.transform);

        ground.transform.localScale = ground.transform.localScale * size;


        mapScript = Resources.Load("Prefabs/ScriptableObjects/Events/BuildMode") as EventsOnMapScript;
        neutralBuilidings = Resources.Load("Prefabs/ScriptableObjects/ModeleZasobow") as BuildingsPresets;
        mapScript.Value = false;
        buildMode = mapScript.Value;
        CreateGrid(size);
    }

    private void Update()
    {
        if (buildMode != mapScript.Value)
        {
            buildMode = mapScript.Value;
            SwitchMode();
        }
    }

    private void CreateGrid(int size)
    {
        GeneratorIlosci(size);
        for (int x = 1; x < size; x++)
        {
            for (int z = 1; z < size; z++)
            {
                Vector3 point = new Vector3(x, 0f, z);
                GameObject temp = Instantiate(gridPrefab, gridConteiner.transform);
                temp.transform.position = point;
                gridPoints.Add(temp);

                temp.GetComponent<GridPoint>().SwitchMode(mapScript.Value);
            }
        }
        GeneratorRozmieszczenia();
    }

    void GeneratorIlosci(int size)
    {
        int random = Random.Range(1, 3);

        Debug.Log("Drewno");
        treeNumber = (int)random + size;
        rockNumber = (int)random + (int)size / 2 - 2;
        coalNumber = (int)random / 2 + 1;
        metalNumber = random - 1;
        uselessNumber = (int)size / 2;

        Debug.Log("Wylosowane: " + "Drzewa: " + treeNumber + " Kamienie: " + rockNumber + " Wegiel: " + coalNumber + " Metal: " + metalNumber + " Bezuzyteczne: " + uselessNumber + " Ogolnie: " + size * size);
    }

    void GeneratorRozmieszczenia()
    {
        int ogolnieDoRozmieszczenia = treeNumber + rockNumber + coalNumber + metalNumber + uselessNumber;

        while (ogolnieDoRozmieszczenia > 0)
        {
            int rand = Random.Range(0, gridPoints.Count - 1);
            GridPoint losulosu = gridPoints[rand].GetComponent<GridPoint>();
            if (losulosu.empty)
            {
                if (treeNumber >= 1)
                {
                    treeNumber--;
                    losulosu.DodajBudynek(neutralBuilidings.budynki[0]);
                }
                else if (rockNumber >= 1)
                {
                    rockNumber--;
                    losulosu.DodajBudynek(neutralBuilidings.budynki[1]);
                }
                else if (coalNumber >= 1)
                {
                    coalNumber--;
                    losulosu.DodajBudynek(neutralBuilidings.budynki[2]);
                }
                else if (metalNumber >= 1)
                {
                    metalNumber--;
                    losulosu.DodajBudynek(neutralBuilidings.budynki[3]);
                }
                else if (uselessNumber >= 1)
                {
                    uselessNumber--;
                    losulosu.DodajBudynek(neutralBuilidings.budynki[4]);
                }

                ogolnieDoRozmieszczenia--;
            }
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        for (int x = 1; x < size; x++)
        {
            for (int z = 1; z < size; z++)
            {
                Vector3 point = new Vector3(x, 0f, z);
                Gizmos.DrawSphere(point, 0.1f);
            }
        }
    }

    public void SwitchMode()
    {

        foreach (GameObject obj in gridPoints)
        {
            obj.GetComponent<GridPoint>().SwitchMode(mapScript.Value);
        }
    }
}

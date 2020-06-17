using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridController : MonoBehaviour
{
    [SerializeField]
    private int size = 1;
    private GameObject gridPrefab;
    private GameObject gridBasePrefab;
    public GameObject gridConteiner;
    public GameObject groundConteriner;
    private BuildingsPresets neutralBuilidings;
    private MapNatureGenerator m_natureMap;
    private List<GameObject> gridPoints = new List<GameObject>();
    private bool buildMode;

    private int treeNumber;
    private int rockNumber;
    private int coalNumber;
    private int metalNumber;
    private int uselessNumber;

    private void Start()
    {
        m_natureMap = GetComponent<MapNatureGenerator>();

        size = 8;
        gridPrefab = Resources.Load("Prefabs/Grid/GridPoint") as GameObject;
        gridBasePrefab = Resources.Load("Prefabs/Objects/Odlamki/Prefabs/baseGrid") as GameObject;
        gridConteiner.transform.position = new Vector3(gridConteiner.transform.position.x - size / 2f, gridConteiner.transform.position.y, gridConteiner.transform.position.z-size/2f);

        GameObject ground = Instantiate(gridBasePrefab, groundConteriner.transform);
        ground.transform.localScale = new Vector3(ground.transform.localScale.x * size, ground.transform.localScale.y, ground.transform.localScale.z * size);

        buildMode = GameControllerScript.Instance.GetBuildMode();

        neutralBuilidings = Resources.Load("Prefabs/ScriptableObjects/ModeleZasobow") as BuildingsPresets;

        CreateGrid(size);
    }

    private void Update()
    {
        if (buildMode != GameControllerScript.Instance.GetBuildMode())
        {
            buildMode = GameControllerScript.Instance.GetBuildMode();
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
                temp.transform.localPosition = point;
                gridPoints.Add(temp);
                m_natureMap.Nature(size, gridConteiner.transform, point);

                temp.GetComponent<GridPoint>().SwitchMode(GameControllerScript.Instance.GetBuildMode());
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

    public void SwitchMode()
    {

        foreach (GameObject obj in gridPoints)
        {
            obj.GetComponent<GridPoint>().SwitchMode(GameControllerScript.Instance.GetBuildMode());
        }
    }

    public int GetSizeOfGrid()
    {
        return size;
    }
}

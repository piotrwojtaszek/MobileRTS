using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering.Universal;

public class UnlockTerrain : MonoBehaviour, IPointerClickHandler
{
    Canvas m_canvas;
    public GridController controller;
    // Start is called before the first frame update
    void Start()
    {
        m_canvas = GetComponent<Canvas>();
        m_canvas.worldCamera = Camera.main;
    }

    public void SetTransform(Vector3 pos)
    {
        transform.position = pos;
    }

    public void Unlock()
    {
        controller.Unlock();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (GameControllerScript.Instance.CheckIfEnoughMinerals(200, 200, 0, 0))
        {
            Unlock();
            Destroy(gameObject);
        }
    }
}

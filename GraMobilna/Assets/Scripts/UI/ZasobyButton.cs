using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZasobyButton : MonoBehaviour
{
    public GameObject zasobyContainer;

    public void ShowHide()
    {
        zasobyContainer.SetActive(!zasobyContainer.activeSelf);
    }
}

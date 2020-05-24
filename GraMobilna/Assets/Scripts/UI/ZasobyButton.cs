using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ZasobyButton : MonoBehaviour
{
    public GameObject zasobyContainer;
    public Image timer;

    public void ShowHide()
    {
        zasobyContainer.SetActive(!zasobyContainer.activeSelf);
    }

    private void Update()
    {
        timer.fillAmount = GameControllerScript.Instance.collectTimer / 10f;
    }
}

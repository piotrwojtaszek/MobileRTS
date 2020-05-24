using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ZasobyStanUI : MonoBehaviour
{
    public TextMeshProUGUI drewno;
    public TextMeshProUGUI kamien;
    public TextMeshProUGUI wegiel;
    public TextMeshProUGUI metal;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        drewno.text = GameControllerScript.Instance.drewnoAmount.ToString();
        kamien.text = GameControllerScript.Instance.kamienAmount.ToString();
        wegiel.text = GameControllerScript.Instance.wegielAmount.ToString();
        metal.text = GameControllerScript.Instance.metalAmount.ToString();
    }
}

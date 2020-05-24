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
    public TextMeshProUGUI drewnoPrzyrost;
    public TextMeshProUGUI kamienPrzyrost;
    public TextMeshProUGUI wegielPrzyrost;
    public TextMeshProUGUI metalPrzyrost;

    // Update is called once per frame
    void Update()
    {
        drewno.text = GameControllerScript.Instance.drewnoAmount.ToString();
        kamien.text = GameControllerScript.Instance.kamienAmount.ToString();
        wegiel.text = GameControllerScript.Instance.wegielAmount.ToString();
        metal.text = GameControllerScript.Instance.metalAmount.ToString();
        drewnoPrzyrost.text = "+" + GameControllerScript.Instance.drewnoIncrece.ToString();
        kamienPrzyrost.text = "+" + GameControllerScript.Instance.kamienIncrece.ToString();
        wegielPrzyrost.text = "+" + GameControllerScript.Instance.wegielIncrece.ToString();
        metalPrzyrost.text = "+" + GameControllerScript.Instance.metalIncrece.ToString();
    }
}

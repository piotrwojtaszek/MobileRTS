using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public AnimationCurve curve;
    public float duration;
    public float size;

    public void OnEnable()
    {
        try
        {
            LeanTween.scale(this.gameObject, Vector3.one * size, duration).setLoopPingPong().setEase(curve);
        }
        catch(Exception e)
        {
            Debug.LogWarning("Błąd");
        }
    }
    public void OnDisable()
    {
        transform.localScale = Vector3.one * 0.2f;
    }
}

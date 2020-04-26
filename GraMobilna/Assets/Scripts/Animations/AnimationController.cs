using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    //public LeanTweenType inType;
    //public LeanTweenType outType;
    public AnimationCurve curve;
    public float duration;
    public float size;

    public void OnEnable()
    {
        LeanTween.scale(gameObject, Vector3.one * size, duration).setLoopPingPong().setEase(curve);
    }
    public void OnDisable()
    {
        transform.localScale = Vector3.one * 0.2f;
    }
}

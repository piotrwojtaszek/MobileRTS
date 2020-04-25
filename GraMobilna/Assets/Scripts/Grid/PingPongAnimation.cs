using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PingPongAnimation
{
    public static void PingPongScale(GameObject obj, float maxSize, float halfTime,AnimationCurve curve)
    {
        Vector3 old = obj.transform.localScale;
        LeanTween.scale(obj, old * maxSize, halfTime).setLoopPingPong().setEase(curve);
    }
}

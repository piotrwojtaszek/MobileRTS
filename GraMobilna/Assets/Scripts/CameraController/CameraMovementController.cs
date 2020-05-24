﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class CameraMovementController : MonoBehaviour
{

    [SerializeField]
    private Camera camera;
    [SerializeField]
    private bool rotate;
    protected Plane plane;
    public float maxZoom = 5f;
    public float minZoom = 30f;
    private void Awake()
    {
        if (camera == null)
        {
            camera = Camera.main;
        }
    }

    private void Update()
    {
        if (GameControllerScript.Instance.GetMoveMode())
        {
            if (Input.touchCount >= 1)
            {
                plane.SetNormalAndPosition(transform.up, transform.position);
            }

            Vector3 delta1 = Vector3.zero;
            Vector3 delta2 = Vector3.zero;

            if (Input.touchCount >= 1)
            {
                delta1 = PlanePositionDelta(Input.GetTouch(0));
                // żeby nie bylo małych ruchow
                if (Input.GetTouch(0).phase == TouchPhase.Moved && delta1.magnitude * 100f > 1f)
                {
                    camera.transform.Translate(delta1, Space.World);
                }
            }

            if (Input.touchCount >= 2)
            {

                var pos1 = PlanePosition(Input.GetTouch(0).position);
                var pos2 = PlanePosition(Input.GetTouch(1).position);

                var pos1a = PlanePosition(Input.GetTouch(0).position - Input.GetTouch(0).deltaPosition);
                var pos2a = PlanePosition(Input.GetTouch(1).position - Input.GetTouch(1).deltaPosition);

                var zoom = Vector3.Distance(pos1, pos2) / Vector3.Distance(pos1a, pos2a);

                if (zoom == 0 || zoom > 10)
                {
                    return;
                }
                Vector3 newPos = Vector3.LerpUnclamped(pos1, camera.transform.position, 1 / zoom);
                if(newPos.y<minZoom && newPos.y > maxZoom)
                {
                    camera.transform.position = newPos;
                }

                camera.transform.position = new Vector3(camera.transform.position.x, Mathf.Clamp(camera.transform.position.y, maxZoom, minZoom), camera.transform.position.z);

                if (rotate && pos2a != pos2)
                {
                    camera.transform.RotateAround(pos1, plane.normal, Vector3.SignedAngle(pos2 - pos1, pos2a - pos1a, plane.normal));
                }
            }

           // camera.transform.position = new Vector3(camera.transform.position.x, Mathf.Clamp(camera.transform.position.y, 2f, 30f), camera.transform.position.z);
        }

    }

    protected Vector3 PlanePositionDelta(Touch touch)
    {
        if (touch.phase != TouchPhase.Moved)
            return Vector3.zero;

        var rayBefore = camera.ScreenPointToRay(touch.position - touch.deltaPosition);
        var rayNow = camera.ScreenPointToRay(touch.position);

        if (plane.Raycast(rayBefore, out var enterBefore) && plane.Raycast(rayNow, out var enterNow))
            return rayBefore.GetPoint(enterBefore) - rayNow.GetPoint(enterNow);


        return Vector3.zero;
    }

    protected Vector3 PlanePosition(Vector2 screenPos)
    {
        var rayNow = camera.ScreenPointToRay(screenPos);
        if (plane.Raycast(rayNow, out var enterNow))
            return rayNow.GetPoint(enterNow);

        return Vector3.zero;
    }
}

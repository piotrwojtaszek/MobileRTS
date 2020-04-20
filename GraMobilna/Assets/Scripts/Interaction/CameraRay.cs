using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class CameraRay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ShootRay();
    }

    void ShootRay()
    {
        if(Input.touchCount == 1)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);

                RaycastHit hitInfo;

                if (Physics.Raycast(ray, out hitInfo))
                {
                    try
                    {
                        hitInfo.collider.GetComponent<OnTouch>().OnTouching();
                    }
                    catch(Exception)
                    {
                        
                    }
                }
            }
        }
    }
}

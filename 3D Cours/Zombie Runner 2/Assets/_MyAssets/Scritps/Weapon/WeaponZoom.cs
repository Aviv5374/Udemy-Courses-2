using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float zoom = 2f;

    #region Rick Version
    [Header("Rick Version")]
    [SerializeField] float zoomedOutFOV = 60f;
    [SerializeField] float zoomedInFOV = 20f;

    bool zoomedInToggle = false;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessZoom();
    }

    void ProcessZoom()
    {
        if (Input.GetMouseButtonDown(1))
        {
            FPCamera.fieldOfView /= zoom;
        }

        if (Input.GetMouseButtonUp(1))
        {
            FPCamera.fieldOfView *= zoom;
        }
    }

    //i dont realy love this approach
    void ProcessZoomRickVersion()
    {
        //the left mouse button toggle the zoom.
        if (Input.GetMouseButtonDown(1))
        {
            if (zoomedInToggle == false)
            {
                zoomedInToggle = true;
                FPCamera.fieldOfView = zoomedInFOV;
            }
            else
            {
                zoomedInToggle = false;
                FPCamera.fieldOfView = zoomedOutFOV;
            }
        }
    }
}

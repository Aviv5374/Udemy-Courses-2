using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{   
    [SerializeField] Camera FPCamera;
    [SerializeField] RigidbodyFirstPersonController fpsController;//i dont realy love this approach
    [SerializeField] float zoom = 2f;
    [SerializeField] float mouseSensitivity = 4f;

    bool isZoomed = false;

    public bool IsZoomed { get { return isZoomed; } }
   

    #region Rick Version
    [Header("Rick Version")]
    [SerializeField] float zoomedOutFOV = 60f;
    [SerializeField] float zoomedInFOV = 20f;
    [SerializeField] float zoomOutSensitivity = 2f;
    [SerializeField] float zoomInSensitivity = .5f;

    bool zoomedInToggle = false;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {        
        //Rick Version
        SetZoomValues(false, zoomedOutFOV, zoomOutSensitivity);
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
            isZoomed = true;
            FPCamera.fieldOfView /= zoom;
            fpsController.mouseLook.XSensitivity /= mouseSensitivity;
            fpsController.mouseLook.YSensitivity /= mouseSensitivity;
        }

        if (Input.GetMouseButtonUp(1))
        {
            isZoomed = false;
            FPCamera.fieldOfView *= zoom;
            fpsController.mouseLook.XSensitivity *= mouseSensitivity;
            fpsController.mouseLook.YSensitivity *= mouseSensitivity;

        }
    }
    
    #region Rick Version Methods

    //i dont realy love this approach
    void ProcessZoomRickVersion()
    {
        //the left mouse button toggle the zoom.
        if (Input.GetMouseButtonDown(1))
        {
            if (zoomedInToggle == false)
            {
                SetZoomValues(true, zoomedInFOV, zoomInSensitivity);                
            }
            else
            {
                SetZoomValues(false, zoomedOutFOV, zoomOutSensitivity);                
            }
        }
    }

    void SetZoomValues(bool isZoomed, float fieldOfView, float mouseSensitivity)
    {
        zoomedInToggle = isZoomed;
        FPCamera.fieldOfView = fieldOfView;
        SetMouseSensitivity(mouseSensitivity);
    }

    void SetMouseSensitivity(float sensitivity)
    {
        fpsController.mouseLook.XSensitivity = sensitivity;
        fpsController.mouseLook.YSensitivity = sensitivity;
    }

    //private void OnDisable()
    //{
    //    SetZoomValues(false, zoomedOutFOV, zoomOutSensitivity);
    //}

    #endregion
}

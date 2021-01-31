using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{

    [SerializeField] Camera fpsCamera;
    [SerializeField] FirstPersonController fpsController;
    [SerializeField] float zoomedOutFOV = 60f;
    [SerializeField] float zoomedInFOV = 30f;
    [SerializeField] float zoomOutSensitivity = 2f;
    [SerializeField] float zoomInSensitivity = .5f;

    

    bool zoomedInToggle = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnDisable() {
        ZoomOut();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1)) {
            if (!zoomedInToggle) {
                ZoomIn();
            } else if (zoomedInToggle) {
                ZoomOut();
            }
        }
    }

    private void ZoomOut() {
        zoomedInToggle = false;
        fpsCamera.fieldOfView = zoomedOutFOV;
        fpsController.m_MouseLook.XSensitivity = zoomOutSensitivity;
        fpsController.m_MouseLook.YSensitivity = zoomOutSensitivity;
    }

    private void ZoomIn() {
        zoomedInToggle = true;
        fpsCamera.fieldOfView = zoomedInFOV;
        fpsController.m_MouseLook.XSensitivity = zoomInSensitivity;
        fpsController.m_MouseLook.YSensitivity = zoomInSensitivity;
    }
}

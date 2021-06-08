using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Camera cameraView;
    [SerializeField] float zoomedIn = 20f;
    [SerializeField] float zoomedOut = 60f;
    [SerializeField] Vector2 sensitivityZoomedIn = new Vector2(0.5f,0.5f);
    [SerializeField] Vector2 sensitivityZoomedOut = new Vector2(2f,2f);

    RigidbodyFirstPersonController fpsController;

    bool zoomedInToggle = false;
    private void Start()
    {
        fpsController = FindObjectOfType<RigidbodyFirstPersonController>();
    }
    private void Update()
    {
        if (Input.GetMouseButton(1))
        {
            if (!zoomedInToggle)
            {
                zoomedInToggle = true;
                cameraView.fieldOfView = zoomedIn;
                SetSensitivity(sensitivityZoomedIn);
            }
        }
        else
        {
            zoomedInToggle = false;
            cameraView.fieldOfView = zoomedOut;
            SetSensitivity(sensitivityZoomedOut);
        }
    }
    private void SetSensitivity(Vector2 sensitivity)
    {
        fpsController.mouseLook.XSensitivity = sensitivity.x;
        fpsController.mouseLook.YSensitivity = sensitivity.y;
    }
}

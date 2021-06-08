using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Camera cameraView;
    [SerializeField] float zoomedIn;
    [SerializeField] float zoomedOut;

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            cameraView.fieldOfView = zoomedIn;
        }
        else
        {
            cameraView.fieldOfView = zoomedOut;
        }
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMouse : MonoBehaviour {

    public float mouseSensitivity;
    public Transform playerBody;

    float xAxisClamp;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;   
    }

    void Update () {
        RotateCamera();

    }

    void RotateCamera()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        float rotAmountX = mouseX * mouseSensitivity;
        float rotAmountY = mouseY * mouseSensitivity;

        xAxisClamp -= rotAmountY;

        Vector3 targetRotCam = transform.rotation.eulerAngles;
        Vector3 targetRotBody = playerBody.rotation.eulerAngles;

        targetRotCam.x -= rotAmountY;
        targetRotCam.z = 0;

        if (xAxisClamp>90)
        {
            xAxisClamp = targetRotCam.x = 90;
        }
        else if (xAxisClamp<-90)
        {
            xAxisClamp = -90;
            targetRotCam.x = 270;
        }

        targetRotBody.y += rotAmountX;

        transform.rotation = Quaternion.Euler(targetRotCam);
        playerBody.rotation = Quaternion.Euler(targetRotBody);

    }
}

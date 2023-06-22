using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class NewCameraSwitch : MonoBehaviour
{
    public CinemachineVirtualCamera playerCamera;
    public CinemachineVirtualCamera bossCamera;

    public KeyCode switchKey = KeyCode.Space;

    private bool isSwitching = false;
    private int playerCameraPriority;
    private int bossCameraPriority;

    private void Start()
    {
        // Store the initial priorities of the cameras
        playerCameraPriority = playerCamera.Priority;
        bossCameraPriority = bossCamera.Priority;
    }

    private void Update()
    {
        if (Input.GetKeyDown(switchKey)) // Changed from GetKey to GetKeyDown
        {
            isSwitching = true;
            StartCoroutine(SwitchCameras());
        }
        else if (Input.GetKeyUp(switchKey)) // Added an else if statement for KeyUp
        {
            isSwitching = false;
            // Set the priorities back to their original values
            playerCamera.Priority = playerCameraPriority;
            bossCamera.Priority = bossCameraPriority;
        }
    }

    private IEnumerator SwitchCameras()
    {
        while (isSwitching)
        {
            // Set the priorities of the cameras to switch between them
            playerCamera.Priority = bossCameraPriority + 1;
            bossCamera.Priority = playerCameraPriority + 1;

            yield return null;
        }
    }
}

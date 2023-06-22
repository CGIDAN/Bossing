using UnityEngine;
using Cinemachine;

public class BossCameraController : MonoBehaviour
{
    public CinemachineVirtualCamera bossCamera;
    public KeyCode aimButton = KeyCode.Space;

    private bool isAiming = false;

    void Update()
    {
        if (Input.GetKeyDown(aimButton))
        {
            isAiming = true;
        }
        else if (Input.GetKeyUp(aimButton))
        {
            isAiming = false;
        }

        if (isAiming)
        {
            bossCamera.Priority = 10;
        }
        else
        {
            bossCamera.Priority = 0;
        }
    }
}

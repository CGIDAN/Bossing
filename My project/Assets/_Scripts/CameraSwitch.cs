using UnityEngine;
using Cinemachine;

public class CameraSwitch : MonoBehaviour
{
    public CinemachineVirtualCamera defaultCamera;
    public CinemachineVirtualCamera bossCamera;
    public string trackBossAxisName = "TrackBoss";

    private void Update()
    {
        if (Input.GetAxis(trackBossAxisName) > 0)
        {
            defaultCamera.gameObject.SetActive(false);
            bossCamera.gameObject.SetActive(true);
        }
        else
        {
            defaultCamera.gameObject.SetActive(true);
            bossCamera.gameObject.SetActive(false);
        }
    }
}

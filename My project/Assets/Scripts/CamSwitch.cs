using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CamSwitch : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera PlayerCam;
    [SerializeField] CinemachineVirtualCamera BossCam;

    private void OnEnbale()
    {
        CamSwitcher.Register(PlayerCam);
        CamSwitcher.Register(BossCam);
        CamSwitcher.SwitchCamera(BossCam);

    }

    private void OnDisable()
    {
        CamSwitcher.Unregister(PlayerCam);
        CamSwitcher.Unregister(BossCam);    
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (CamSwitcher.IsActiveCamera(PlayerCam))
            {
                CamSwitcher.SwitchCamera(BossCam);
            }
            else if (CamSwitcher.IsActiveCamera(BossCam))
            {
                CamSwitcher.SwitchCamera(PlayerCam);
            }
        }
    }
}

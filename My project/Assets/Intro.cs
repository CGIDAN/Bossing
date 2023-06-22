using UnityEngine;
using Cinemachine;
using StarterAssets;

public class Intro : MonoBehaviour
{
    private ThirdPersonController playerController;
    public Animator cameraAnimator;

    private bool isCameraAnimationComplete = false;

    private void Start()
    {
        // Disable the player controller at the beginning
        playerController = FindObjectOfType<ThirdPersonController>();
        if (playerController != null)
        {
            playerController.enabled = false;
        }
    }

    private void Update()
    {
        if (!isCameraAnimationComplete)
        {
            // Check if the camera animation sequence is complete
            if (CameraAnimationSequenceComplete())
            {
                isCameraAnimationComplete = true;
                ActivatePlayerCamera();
            }
        }
    }

    private bool CameraAnimationSequenceComplete()
    {
        // Replace '3f' with the duration of the camera animation
        return Time.timeSinceLevelLoad >= 3f;
    }

    public void ActivatePlayerCamera()
    {
        // Find the PlayerFollowCamera in the scene
        GameObject playerFollowCamera = GameObject.Find("MainCamera");

        // Enable the player controller
        if (playerController != null)
        {
            playerController.enabled = true;
        }

        // Enable the player camera (PlayerFollowCamera) and disable the intro camera
        if (playerFollowCamera != null)
        {
            playerFollowCamera.SetActive(true);
        }

        if (cameraAnimator != null)
        {
            cameraAnimator.enabled = false;
        }
    }
}
using UnityEngine;

public class BossSoundController : MonoBehaviour
{
    public AudioSource audioSource;

    public void SmashSound()
    {
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }
}
using UnityEngine;

public class BossParticleController : MonoBehaviour
{
    public ParticleSystem[] particleSystems;
    public float delay = 2f;

    private bool[] hasTriggered;

    private void Start()
    {
        InitializeParticleSystems();
    }

    private void Update()
    {
        for (int i = 0; i < particleSystems.Length; i++)
        {
            if (hasTriggered[i] && Time.time >= delay)
            {
                particleSystems[i].Stop();
                hasTriggered[i] = false;
            }
        }
    }

    public void TriggerParticleEffect()
    {
        for (int i = 0; i < particleSystems.Length; i++)
        {
            if (!hasTriggered[i])
            {
                particleSystems[i].Play();
                hasTriggered[i] = true;
            }
        }
    }

    private void InitializeParticleSystems()
    {
        hasTriggered = new bool[particleSystems.Length];

        for (int i = 0; i < particleSystems.Length; i++)
        {
            particleSystems[i].Stop();
            hasTriggered[i] = false;
        }
    }
}
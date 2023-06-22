using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    public int damageAmount = 3;

    void OnTriggerEnter(Collider other)
    {
        BossHealth bossHealth = other.GetComponent<BossHealth>();

        if (bossHealth != null)
        {
            bossHealth.TakeDamage(damageAmount);
        }
    }
}
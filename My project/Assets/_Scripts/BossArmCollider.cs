using UnityEngine;

public class BossArmCollider : MonoBehaviour
{
    public int damageAmount = 10;

    void OnTriggerEnter(Collider other)
    {
        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damageAmount);
        }
    }
}
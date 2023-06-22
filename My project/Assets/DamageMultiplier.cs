using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageMultiplier : MonoBehaviour
{
    public int extraDamage = 10; // amount of extra damage to apply when hit
    public BossHealth bossHealth; // reference to the boss health script
    public float damageReductionDuration = 10f;
    public float damageReductionInterval = 5f;
    public float damageReductionAmount = 0.5f;
    public Color vulnerableEmissiveColor;

    private bool isDamageReductionActive = false;
    private float damageReductionTimer;
    private Renderer vulnerableRenderer;
    private Material emissiveMaterial;
    private Color defaultEmissiveColor;

    private void Start()
    {
        vulnerableRenderer = GetComponent<Renderer>();
        emissiveMaterial = vulnerableRenderer.material;
        defaultEmissiveColor = emissiveMaterial.GetColor("_EmissionColor");
    }

    void OnTriggerEnter(Collider other)
    {
        // check if the object that collided with us is a projectile
        PlayerProjectile projectile = other.GetComponent<PlayerProjectile>();
        if (projectile != null)
        {
            // apply extra damage to the boss and destroy the projectile
            float totalDamage = projectile.damageAmount + extraDamage;

            if (isDamageReductionActive)
            {
                totalDamage *= damageReductionAmount;
            }

            bossHealth.TakeDamage((int)totalDamage);
            Destroy(projectile.gameObject);

            if (!isDamageReductionActive)
            {
                StartCoroutine(ActivateDamageReduction());
            }
        }
    }

    private IEnumerator ActivateDamageReduction()
    {
        isDamageReductionActive = true;
        emissiveMaterial.SetColor("_EmissionColor", vulnerableEmissiveColor);

        yield return new WaitForSeconds(damageReductionDuration);

        isDamageReductionActive = false;
        emissiveMaterial.SetColor("_EmissionColor", defaultEmissiveColor);
    }
}
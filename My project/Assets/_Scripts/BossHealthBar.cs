using UnityEngine;
using UnityEngine.UI;

public class BossHealthBar : MonoBehaviour
{
    public BossHealth bossHealth;
    private Image foregroundImage;

    void Start()
    {
        foregroundImage = GetComponent<Image>();
    }

    void Update()
    {
        float healthPercent = (float)bossHealth.currentHealth / bossHealth.maxHealth;
        foregroundImage.rectTransform.sizeDelta = new Vector2(healthPercent * bossHealth.maxHealth, foregroundImage.rectTransform.sizeDelta.y);
    }
}

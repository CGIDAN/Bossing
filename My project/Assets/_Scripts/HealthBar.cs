using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public PlayerHealth playerHealth;
    private Image foregroundImage;

    void Start()
    {
        foregroundImage = GetComponent<Image>();
    }

    void Update()
    {
        float healthPercent = (float)playerHealth.currentHealth / playerHealth.maxHealth;
        foregroundImage.rectTransform.sizeDelta = new Vector2(healthPercent * playerHealth.maxHealth, foregroundImage.rectTransform.sizeDelta.y);
    }
}

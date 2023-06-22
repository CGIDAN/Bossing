using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public UnityEvent onHealthChanged;
    public UnityEvent onHealthDepleted;
    public GameObject playerDeadCanvas;

    public float fallDamageThreshold = 5f; // Minimum fall height for fall damage
    public float fallDamageMultiplier = 1f; // Multiplier for fall damage

    private float fallTimer = 0f;
    private bool isGrounded = true;
    
    private bool isPlayerDead = false;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        if (!isGrounded)
        {
            fallTimer += Time.deltaTime;
        }
        else
        {
            if (fallTimer > 0)
            {
                CalculateFallDamage(fallTimer);
                fallTimer = 0;
            }
        }
    }

    public void TakeDamage(int damage)
    {
        if (isPlayerDead)
            return;

        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            onHealthDepleted.Invoke();
            playerDeadCanvas.SetActive(true);
            PauseGame();
            isPlayerDead = true;

            StartCoroutine(LoadMainMenuAfterDelay(3f));
        }
        else
        {
            onHealthChanged.Invoke();
        }
    }

    private void PauseGame()
    {
        Time.timeScale = 0f;
    }

    private System.Collections.IEnumerator LoadMainMenuAfterDelay(float delay)
    {
        yield return new WaitForSecondsRealtime(delay);
        Time.timeScale = 1f; // Resume the game
        SceneManager.LoadScene("MainMenu");
    }

    void CalculateFallDamage(float fallTime)
    {
        float fallHeight = fallTime * fallTime * 0.5f * 9.81f; // Calculate fall height based on free fall formula
        if (fallHeight >= fallDamageThreshold)
        {
            int damage = Mathf.RoundToInt((fallHeight - fallDamageThreshold) * fallDamageMultiplier);
            TakeDamage(damage);
        }
    }

    // Call this function from your third person controller when the player lands on the ground
    public void OnGrounded()
    {
        isGrounded = true;
    }

    // Call this function from your third person controller when the player leaves the ground
    public void OnNotGrounded()
    {
        isGrounded = false;
    }
}

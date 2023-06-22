using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class BossHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public UnityEvent onHealthChanged;
    public UnityEvent onHealthDepleted;
    public GameObject bossDownCanvas;
    public TMPro.TextMeshProUGUI timeText;

    private bool isBossDead = false;
    private float defeatTime;

    private bool isMainMenuLoading = false;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        if (isBossDead)
            return;

        UpdateTimeText();
    }


    public void TakeDamage(int damage)
    {
        if (isBossDead)
            return;

        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            onHealthDepleted.Invoke();
            bossDownCanvas.SetActive(true);
            PauseGame();
            isBossDead = true;
            defeatTime = Time.time;

            StartCoroutine(LoadMainMenuDelayed(3f));
        }
        else
        {
            onHealthChanged.Invoke();
        }
    }

    private void UpdateTimeText()
    {
        float elapsedTime = Time.timeSinceLevelLoad - defeatTime;
        timeText.text = "Time: " + elapsedTime.ToString("F2") + "s";
    }

    private void PauseGame()
    {
        Time.timeScale = 0f;
    }
    private System.Collections.IEnumerator LoadMainMenuDelayed(float delay)
    {
        if (!isMainMenuLoading)
        {
            isMainMenuLoading = true;
            yield return new WaitForSecondsRealtime(delay);
            Time.timeScale = 1f; // Resume the game
            SceneManager.LoadScene("MainMenu"); // Replace "MainMenu" with the name of your main menu scene
        }
    }
}
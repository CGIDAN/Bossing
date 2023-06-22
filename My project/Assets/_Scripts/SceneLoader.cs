using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class SceneLoader : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider loadingBar;

    public void LoadScene(int levelIndex)
    {
        Time.timeScale = 1f;
        StartCoroutine(LoadScenesAsynchronously(levelIndex));
    }

    IEnumerator LoadScenesAsynchronously(int levelIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(levelIndex);
        loadingScreen.SetActive(true);
        while (!operation.isDone)
        {
            loadingBar.value = operation.progress;
            yield return null;
        }
    }
    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }


}

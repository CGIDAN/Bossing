using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FightText : MonoBehaviour
{
    public float displayDuration = 3f; // Duration in seconds that the test should appear

    private void Start()
    {
        StartCoroutine(DeactivateGameObject());
    }

    private IEnumerator DeactivateGameObject()
    {
        yield return new WaitForSeconds(displayDuration);
        gameObject.SetActive(false);
    }
}
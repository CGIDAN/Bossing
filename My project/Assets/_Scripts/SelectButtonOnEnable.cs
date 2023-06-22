using UnityEngine;
using UnityEngine.UI;

public class SelectButtonOnEnable : MonoBehaviour
{
    public Button startButton;

    void OnEnable()
    {
        startButton.Select();
    }
}

using UnityEngine;
using UnityEngine.EventSystems;

public class MainMenuController : MonoBehaviour
{
    public GameObject startButton;

    void Start()
    {
        // Highlight the start button
        EventSystem.current.SetSelectedGameObject(startButton);

        // Activate mouse/keyboard input
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.None;
    }
}
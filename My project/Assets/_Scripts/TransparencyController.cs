using UnityEngine;

public class TransparencyController : MonoBehaviour
{
    private Renderer objectRenderer;
    private Color initialColor;
    private Color transparentColor;
    public float transparency = 0.5f;

    void Start()
    {
        // Get the renderer component of the object
        objectRenderer = GetComponent<Renderer>();

        // Save the initial color of the object
        initialColor = objectRenderer.material.color;

        // Set the transparent color with the same values as the initial color, but with lower alpha
        transparentColor = new Color(initialColor.r, initialColor.g, initialColor.b, transparency);
    }

    void OnTriggerEnter(Collider other)
    {
        // When the player enters the trigger zone of the object, make it transparent
        if (other.CompareTag("Player"))
        {
            objectRenderer.material.color = transparentColor;
        }
    }

    void OnTriggerExit(Collider other)
    {
        // When the player exits the trigger zone of the object, restore its initial color
        if (other.CompareTag("Player"))
        {
            objectRenderer.material.color = initialColor;
        }
    }
}

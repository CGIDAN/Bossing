using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public float speed = 2f;
    public float distance = 10f;
    public float rotationSpeed = 5f;
    public Transform startPos;
    public Transform endPos;
    public bool playerOnPlatform;

    void Update()
    {
        if (playerOnPlatform)
        {
            // Move the player along with the platform
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.transform.position += transform.position - transform.parent.position;
        }

        // Move the platform back and forth
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, endPos.position, step);
        if (Vector3.Distance(transform.position, endPos.position) < 0.1f)
        {
            Vector3 temp = endPos.position;
            endPos.position = startPos.position;
            startPos.position = temp;
        }

        // Rotate the platform horizontally in air
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerOnPlatform = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerOnPlatform = false;
        }
    }
}
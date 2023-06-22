using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOnPlatform : MonoBehaviour
{
    private Rigidbody rb;
    private bool onPlatform = false;
    private Vector3 platformVelocity;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (onPlatform)
        {
            rb.velocity += platformVelocity;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("MovingPlatform"))
        {
            onPlatform = true;
            platformVelocity = collision.gameObject.GetComponent<Rigidbody>().velocity;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("MovingPlatform"))
        {
            onPlatform = false;
        }
    }
}
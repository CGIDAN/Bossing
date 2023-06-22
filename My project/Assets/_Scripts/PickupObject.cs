using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObject : MonoBehaviour
{
    public GameObject gunObject; // Assign the gun object to this field in the Inspector
    public string weaponParameterName = "weapon"; // Set the parameter name in the Inspector
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) // Check if the object that touched the pickup is the player
        {
            gameObject.SetActive(false); // Deactivate the pickup object

            gunObject.SetActive(true); // Activate the gun object attached to the player
           
            
            // Set the "weapon 1" parameter to true on the player animator
            Animator playerAnimator = other.gameObject.GetComponent<Animator>();
            if (playerAnimator != null)
            {
                playerAnimator.SetBool(weaponParameterName, true);
            }

            // Enable the ProjectileShoot script on the player
            other.gameObject.GetComponent<Projectile_Shoot>().enabled = true;
        }
    }
}
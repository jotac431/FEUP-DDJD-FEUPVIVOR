using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectiblePickupController : MonoBehaviour
{
    public float boostedMovementVelocity = 2;
    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D collision){
        Debug.Log("Collision detected with " + collision.gameObject.tag);
        if (collision.gameObject.CompareTag("collectible-speed"))
        {
            GetComponent<PlayerMovement>().movementVelocity *= boostedMovementVelocity;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("collectible-health"))
        {
            GetComponent<PlayerController>().health = GetComponent<PlayerController>().maxHealth;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("collectible-firerate"))
        {
            GetComponent<gunController>().fireRateBoost = true;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("collectible-attack"))
        {
            GetComponent<gunController>().attackBoost = true;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("collectible-coin"))
        {
            GetComponent<PlayerController>().coins += 1;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("collectible-pen"))
        {
            if (!GetComponent<PlayerController>().smgUnlocked)
            {
                GetComponent<PlayerController>().smgUnlocked = true;
            }
            else if(!GetComponent<PlayerController>().shotgunUnlocked)
            {
                GetComponent<PlayerController>().shotgunUnlocked = true;
            }
            else if (!GetComponent<PlayerController>().sniperUnlocked)
            {
                GetComponent<PlayerController>().sniperUnlocked = true;
            }
            else if (!GetComponent<PlayerController>().mgUnlocked)
            {
                GetComponent<PlayerController>().mgUnlocked = true;
            }
            else
            {
                Debug.LogWarning("A pen drive was collected but all weapons are unlocked!");
            }

            Destroy(collision.gameObject);
        }
    }
}

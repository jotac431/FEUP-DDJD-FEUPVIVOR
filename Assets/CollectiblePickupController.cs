using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectiblePickupController : MonoBehaviour
{
    public float boostedMovementVelocity = 2;

    public float velocityBoostDuration = 4; //seconds
    float velocityBoostStartTime = -1;

    public float firerateBoostDuration = 4; //seconds
    float firerateBoostStartTime = -1;

    public float attackBoostDuration = 4; //seconds
    float attackBoostStartTime = -1;


    private void Update()
    {
        if (Time.time - velocityBoostStartTime > velocityBoostDuration && velocityBoostStartTime != -1)
        {
            velocityBoostStartTime = -1;
            GetComponent<PlayerMovement>().movementVelocity /= boostedMovementVelocity;
        }
        if (Time.time - firerateBoostStartTime > firerateBoostDuration && firerateBoostStartTime != -1)
        {
            firerateBoostStartTime = -1;
            GetComponent<gunController>().fireRateBoost = true;
        }
        if (Time.time - attackBoostStartTime > attackBoostDuration && attackBoostStartTime != -1)
        {
            attackBoostStartTime = -1;
            GetComponent<gunController>().attackBoost = true;
        }
    }

    void OnCollisionEnter2D(Collision2D collision){
        //Debug.Log("Collision detected with " + collision.gameObject.tag);
        if (collision.gameObject.CompareTag("collectible-speed"))
        {
            if (velocityBoostStartTime != -1)
            {
                velocityBoostStartTime = Time.time;
                Destroy(collision.gameObject);
            }
            else
            {
                velocityBoostStartTime = Time.time;
                GetComponent<PlayerMovement>().movementVelocity *= boostedMovementVelocity;
                Destroy(collision.gameObject);
            }
        }
        if (collision.gameObject.CompareTag("collectible-health"))
        {
            GetComponent<PlayerController>().Heal(100);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("collectible-firerate"))
        {
            if (firerateBoostStartTime != -1)
            {
                firerateBoostStartTime = Time.time;
                Destroy(collision.gameObject);
            }
            else
            {
                firerateBoostStartTime = Time.time;
                GetComponent<gunController>().fireRateBoost = true;
                Destroy(collision.gameObject);
            }
        }
        if (collision.gameObject.CompareTag("collectible-attack"))
        {
            if (attackBoostStartTime != -1)
            {
                attackBoostStartTime = Time.time;
                Destroy(collision.gameObject);
            }
            else
            {
                attackBoostStartTime = Time.time;
                GetComponent<gunController>().attackBoost = true;
                Destroy(collision.gameObject);
            }
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunController : MonoBehaviour
{
    public float weaponType = 0; //What gun is currently active
    public bool attackBoost = false; //If there is an active attackBoost
    public bool fireRateBoost = false; //If there is an active fire rate boost
    public Transform bulletSpawnPoint; //Where to spawn the bullets
    public GameObject bulletPrefab; //The bullet prefab to spawn
    public float bulletSpeed = 20; //The speed of the bullets
    public float fireRate = 3; //The fire rate in bullets per second
    float lastFireTime = -1; //Timestamp of the last time a bullet was fired
    void Update()
    {

        //Update firerate

        if(weaponType == 0) //Pistol
        {
            fireRate = 2;
        }
        if (weaponType == 1) //SMG
        {
            fireRate = 4;
        }
        if (weaponType == 2) //Shotgun
        {
            fireRate = 1;
        }
        if (weaponType == 3) //Sniper
        {
            fireRate = 1/3.0f;
        }
        if (weaponType == 4) //Minigun
        {
            fireRate = 8;
        }
        if (fireRateBoost) //Check if there is a fire rate boost
        {
            fireRate *= 2;
        }


        if (Input.GetKey("space") && (Time.time - lastFireTime) >= 1/fireRate && GameObject.Find("GameController").GetComponent<GameController>().gameState == "playing"){
            lastFireTime = Time.time; //Register the last time a bullet was fired
            float xComp = GetComponent<PlayerMovement>().xComp;
            float yComp = GetComponent<PlayerMovement>().yComp; //Get the direction the player is facing
            GameObject bullet;
            if (yComp < 0) //If we are trying to shoot down, the bullet must be spawned bellow the player so that it doesnt collide with it
            {
                bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position + new Vector3(0.3f, -0.55f, 0), bulletSpawnPoint.rotation); //Create the bullet
            }
            else if (yComp > 0)
            {
                bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position + new Vector3(0.3f, +0.55f, 0), bulletSpawnPoint.rotation);
            }
            else if (xComp == 1)
            {
                bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position + new Vector3(0.6f, 0, 0), bulletSpawnPoint.rotation); //Create the bullet

            }
            else
            {
                bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation); //Create the bullet
            }
            Debug.Log("Rotating with angle " + Mathf.Atan2(xComp, yComp));
            bullet.transform.Rotate(Vector3.forward,Mathf.Atan2(yComp,xComp)*180/Mathf.PI);
            bullet.GetComponent<Rigidbody2D>().velocity = new Vector3(xComp*bulletSpeed,yComp*bulletSpeed,0); //Set the velocity of the bullet relative to the direction te player is facing
            bullet.GetComponent<BulletBehaviour>().weaponType = weaponType; //Set the weapon type that fired the bullet
            bullet.GetComponent<BulletBehaviour>().startingPosition = bulletSpawnPoint.position; //Set the position from which the bullet was fired
            bullet.GetComponent<BulletBehaviour>().attackBoost = attackBoost; //Set if there is an attack boost active
        }

    }
}

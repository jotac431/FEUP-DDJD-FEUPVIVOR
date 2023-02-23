using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunController : MonoBehaviour
{
    public float weaponType = 0;
    public bool attackBoost = false;
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10;
    public float fireRate = 3; //bullets per second
    float lastFireTime = -1;
    void Update()
    {
        if (Input.GetKey("space") && (Time.time - lastFireTime) >= 1/fireRate){
            lastFireTime = Time.time; //Register the last time a bullet was fired
            var bullet = Instantiate(bulletPrefab,bulletSpawnPoint.position,bulletSpawnPoint.rotation); //Create the bullet
            float xComp = GetComponent<PlayerMovement>().xComp;
            float yComp = GetComponent<PlayerMovement>().yComp; //Get the direction the player is facing
            bullet.GetComponent<Rigidbody2D>().velocity = new Vector3(xComp*bulletSpeed,yComp*bulletSpeed,0); //Set the velocity of the bullet relative to the direction te player is facing
            bullet.GetComponent<BulletBehaviour>().weaponType = weaponType; //Set the weapon type that fired the bullet
            bullet.GetComponent<BulletBehaviour>().startingPosition = bulletSpawnPoint.position; //Set the position from which the bullet was fired
            bullet.GetComponent<BulletBehaviour>().attackBoost = attackBoost; //Set if there is an attack boost active
        }
    }
}

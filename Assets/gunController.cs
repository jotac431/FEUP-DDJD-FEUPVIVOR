using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunController : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10;
    public float fireRate = 3; //bullets per second
    float lastFireTime = -1;
    void Update()
    {
        if (Input.GetKey("space") && (Time.time - lastFireTime) >= 1/fireRate){
            lastFireTime = Time.time;
            var bullet = Instantiate(bulletPrefab,bulletSpawnPoint.position,bulletSpawnPoint.rotation);
            float xComp = GetComponent<PlayerMovement>().xComp;
            float yComp = GetComponent<PlayerMovement>().yComp;
            bullet.GetComponent<Rigidbody2D>().velocity = new Vector3(xComp*bulletSpeed,yComp*bulletSpeed,0);
        }
    }
}

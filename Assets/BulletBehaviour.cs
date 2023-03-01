using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public Vector3 startingPosition;
    public float weaponType;
    public bool attackBoost = false;

    float bulletMaxRange = 100;

    void Start(){
        //Define the maximum range
        if (weaponType == 0){ //pistol
            bulletMaxRange = 4;
        }else if (weaponType == 1){ //SMG
            bulletMaxRange = 6;
        }else if (weaponType == 1){ //Shotgun
            bulletMaxRange = 2.5f;
        }else if (weaponType == 1){ //Sniper
            bulletMaxRange = 12;
        }else if (weaponType == 1){ //MiniGun
            bulletMaxRange = 7;
        }
    }

    void OnCollisionEnter2D(Collision2D collision){
        if (!collision.gameObject.CompareTag("bullet") && !collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Bullet collided with " + collision.gameObject.tag);
            Destroy(gameObject);
        }
    }

    void Update(){
        // Destroy bullet if it has gone too far
        if (Vector3.Distance(startingPosition,GetComponent<Transform>().position) > bulletMaxRange){
            Destroy(gameObject);
            
        }
    }
}

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
        if (weaponType == 0){ //pistol
            bulletMaxRange = 4;
        }else if (weaponType == 1){ //SMG
            bulletMaxRange = 6;
        }else if (weaponType == 1){ //Shotgun
            bulletMaxRange = 2.5f;
        }else if (weaponType == 1){ //Sniper
            bulletMaxRange = 12;
        }else if (weaponType == 1){ //Machine Gun
            bulletMaxRange = 7;
        }
        Debug.Log("calculated max range");
    }

    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D collision){
        Destroy(gameObject);
    }

    void Update(){
        if (Vector3.Distance(startingPosition,GetComponent<Transform>().position) > bulletMaxRange){
            Debug.Log("got to limit");
            Destroy(gameObject);
            
        }
    }
}

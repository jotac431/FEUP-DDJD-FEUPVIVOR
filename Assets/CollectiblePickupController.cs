using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectiblePickupController : MonoBehaviour
{
    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D collision){
        Debug.Log("Collision detected");
        if (collision.gameObject.tag == "collectible"){
            GetComponent<PlayerMovement>().movementVelocity *= 2;
            Destroy(collision.gameObject);
        }
    }
}

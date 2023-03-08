using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public float movementVelocity = 5;
    public float xComp = -1;
    public float yComp = 0;
    // Update is called once per frame
    void Update()
    {
        string gs = GameObject.Find("GameController").GetComponent<GameController>().gameState;
        if (gs != "playing")
        {
            return;
        }
        float lastXComp = xComp;
        float lastYComp = yComp;
        xComp = 0;
        yComp = 0;
        if (Input.GetKey(KeyCode.D)){
            xComp += 1;
        }
        if (Input.GetKey(KeyCode.A)){
            xComp -= 1;
        }
        if (Input.GetKey(KeyCode.W)){
            yComp += 1;
        }
        if (Input.GetKey(KeyCode.S)){
            yComp -= 1;
        }
        if (Mathf.Abs(xComp) + Mathf.Abs(yComp) == 2){
            xComp*=0.707f;
            yComp*=0.707f;
        }
        GetComponent<Rigidbody2D>().velocity = new Vector3(movementVelocity*xComp,movementVelocity*yComp,0);

        if(xComp == 0 && yComp == 0){
            xComp = lastXComp;
            yComp = lastYComp;
        }
    }


}

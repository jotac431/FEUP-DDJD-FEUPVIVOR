using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{

    // Adjust the speed for the application.
    public float speed = 1.0f;
    public int damage = 10;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var pos = GameObject.Find("Player").transform.position;

        // Move our position a step closer to the target.
        var step = speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, pos, step);
        //transform.position = transform.position + new Vector3(step, step, 0);
        //GameObject.FindGameObjectWithTag("Player").transform.position;

    }
}

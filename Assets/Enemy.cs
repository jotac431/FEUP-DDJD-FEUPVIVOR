using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{

    // Adjust the speed for the application.
    public float speed = 1.0f;
    public int damage = 10;
    public int health = 100;
    public int maxHealth = 100;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isDead())
        {
            Destroy(gameObject);
            return;
        }

        var pos = GameObject.Find("Player").transform.position;

        // Move our position a step closer to the target.
        if (speed < 1.0f)
        {
            speed += 0.2f;
        }
        var step = speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, pos, step);
        //transform.position = transform.position + new Vector3(step, step, 0);
        //GameObject.FindGameObjectWithTag("Player").transform.position;

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            Debug.Log("Enemy collided with " + collision.gameObject.tag);
            TakeDamage(50);
        }

        if (collision.gameObject.name == "Player")
        {
            Debug.Log("Enemy collided with " + collision.gameObject.tag);
            speed = -5.0f;
        }
    }

    public bool isDead()
    {
        return health == 0;
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health < 0)
            health = 0;

        //healthBar.SetHealth(health);
    }
}

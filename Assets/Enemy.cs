using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    public GameObject enemyPrefab;
    // Adjust the speed for the application.
    public float baseSpeed = 1.0f;
    public float speed = 1.0f;
    public int damage = 10;
    public int health = 100;
    public int maxHealth = 100;
    public int cost;
    public float dropRate = 0.2f;

    public GameObject attackCollectible;
    public GameObject firerateCollectible;
    public GameObject healthCollectible;
    public GameObject velocityCollectible;
    public GameObject coinCollectible;
    public GameObject penCollectible;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isDead())
        {
            Destroy(gameObject);
            return;
        }

        var pos = GameObject.Find("Player").transform.position;

        // Move our position a step closer to the target.
        if (speed < baseSpeed)
        {
            speed += 0.2f;
        }
        var step = speed * Time.deltaTime; // calculate distance to move
        if (GameObject.Find("GameController").GetComponent<GameController>().gameState == "playing")
        {
            transform.position = Vector3.MoveTowards(transform.position, pos, step);
        }
        //transform.position = transform.position + new Vector3(step, step, 0);
        //GameObject.FindGameObjectWithTag("Player").transform.position;

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //Enemies bounce back when hit by bullet
        if (collision.gameObject.CompareTag("bullet"))
        {
            //Debug.Log("Enemy collided with " + collision.gameObject.tag);
            speed = -3.0f;
            TakeDamage(20);
        }

        //Enemies bounce back when they collide with player
        if (collision.gameObject.name == "Player")
        {
            //Debug.Log("Enemy collided with " + collision.gameObject.tag);
            speed = -3.0f;
        }
    }

    public bool isDead()
    {
        return health == 0;
    }

    public void TakeDamage(int amount)
    {
        //Reduces health
        health -= amount;
        if (health < 0)
            health = 0;
        if (health == 0)
        {
            if (GameObject.Find("WaveSpawner").GetComponent<WaveSpawner>().spawnedEnemies.Count == 1)
            {
                DropItem("pen");
            }else{
                DropItem(null);
            }
        }

        //Set less transparency when enemies lose HP
        var color = gameObject.GetComponent<SpriteRenderer>().color;
        if (health >= 80)
            gameObject.GetComponent<SpriteRenderer>().color = new Color(color.r, color.g, color.b, 1f);
        else if (health >= 60)
            gameObject.GetComponent<SpriteRenderer>().color = new Color(color.r, color.g, color.b, 0.8f);
        else if (health >= 40)
            gameObject.GetComponent<SpriteRenderer>().color = new Color(color.r, color.g, color.b, 0.6f);
        else if (health >= 20)
            gameObject.GetComponent<SpriteRenderer>().color = new Color(color.r, color.g, color.b, 0.4f);
        else
            gameObject.GetComponent<SpriteRenderer>().color = new Color(color.r, color.g, color.b, 0.2f);

        //healthBar.SetHealth(health);
    }

    void OnDestroy()
    {
        if (GameObject.FindGameObjectWithTag("WaveSpawner") != null)
        {
            GameObject.FindGameObjectWithTag("WaveSpawner").GetComponent<WaveSpawner>().spawnedEnemies.Remove(gameObject);
        }

    }

    void DropItem(string type)
    {
        //Drops items depending on type (attack, firerate, velocity, health, pen, coin or null)
        //If type is null, a random item is dropped with drop rate equal to the one defined by dropRate and a coin


        Transform myT = GetComponent<Transform>();
        if (type == null) //drop random item and coin
        {
            Instantiate(coinCollectible, myT.position + new Vector3(UnityEngine.Random.value * 2 - 1, UnityEngine.Random.value * 2 - 1), myT.rotation);
            float a = UnityEngine.Random.value;
            if (a < dropRate/4)
            {
                type = "attack";
            }else if(a < dropRate/2)
            {
                type = "firerate";
            }else if(a < dropRate*3/4)
            {
                type = "health";
            }
            else if(a < dropRate)
            {
                type = "velocity";
            }
        }
        Debug.Log("Dropping " + type);
        if(type == "attack")
        {
            Instantiate(attackCollectible,myT.position + new Vector3(UnityEngine.Random.value*2-1, UnityEngine.Random.value * 2 - 1), myT.rotation);
        }else if (type == "firerate")
        {
            Instantiate(firerateCollectible, myT.position + new Vector3(UnityEngine.Random.value * 2 - 1, UnityEngine.Random.value * 2 - 1), myT.rotation);
        }else if (type == "health")
        {
            Instantiate(healthCollectible, myT.position + new Vector3(UnityEngine.Random.value * 2 - 1, UnityEngine.Random.value * 2 - 1), myT.rotation);
        }else if (type == "velocity")
        {
            Instantiate(velocityCollectible, myT.position + new Vector3(UnityEngine.Random.value * 2 - 1, UnityEngine.Random.value * 2 - 1), myT.rotation);
        }
        else if (type == "coin")
        {
            Instantiate(velocityCollectible, myT.position + new Vector3(UnityEngine.Random.value * 2 - 1, UnityEngine.Random.value * 2 - 1), myT.rotation);
        }
        else if (type == "pen")
        {
            Instantiate(penCollectible, myT.position + new Vector3(UnityEngine.Random.value * 2 - 1, UnityEngine.Random.value * 2 - 1), myT.rotation);
        }
    }


}

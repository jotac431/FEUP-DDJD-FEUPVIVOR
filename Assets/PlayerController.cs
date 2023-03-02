using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public HealthBar healthBar;

    public int health = 100;
    public int maxHealth = 100;
    public int coins = 0;
    public bool smgUnlocked = false;
    public bool shotgunUnlocked = false;
    public bool sniperUnlocked = false;
    public bool mgUnlocked = false;

    public bool isDead()
    {
        return health == 0;
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health < 0)
            health = 0;

        healthBar.SetHealth(health);
    }

    public void UnlockWeapon(int weaponID)
    {
        switch (weaponID)
        {
            case 1:
                smgUnlocked = true; break;
            case 2:
                shotgunUnlocked= true; break;
            case 3:
                sniperUnlocked= true; break;   
            case 4:
                mgUnlocked= true; break;
            default:
                Debug.LogError("Invalid argumnet given to unlockWeapon (weaponID must be between 1 and 4 and got " + weaponID + ")");
                break;
        }
    }

    public bool getWeaponLockedStatus(int weaponID)
    {
        switch (weaponID)
        {
            case 1:
                return smgUnlocked; 
            case 2:
                return shotgunUnlocked; 
            case 3:
                return sniperUnlocked; 
            case 4:
                return mgUnlocked; 
            default:
                Debug.LogError("Invalid argumnet given to unlockWeapon (weaponID must be between 1 and 4 and got " + weaponID + ")");
                return false;
                
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Enemy")
        {
            Debug.Log("Player collided with " + collision.gameObject.name);
            TakeDamage(collision.gameObject.GetComponent<Enemy>().damage);
            Debug.Log("HP " + health);
            //Destroy(collision.gameObject);
        }
    }
}


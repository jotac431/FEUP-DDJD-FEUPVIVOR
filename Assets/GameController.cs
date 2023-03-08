using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public string gameState = "starting";

    bool weaponMenuOpened = false;
    float weaponMenuAnimationStartTime = -1;
    public float weaponMenuAnimationDuration = 1; //Duration in seconds
    RectTransform rt;
    GameObject playingInterface;

    int score = 0;
    public GameOverScreen GameOverScreen;

    void Start()
    {
        rt = GameObject.Find("pc-panel").GetComponent<RectTransform>();
        rt.position = new Vector3(1000, -150, 1100);
        playingInterface = GameObject.Find("playing-interface");
        playingInterface.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //Check Game Over
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().isDead())
            GameOver();

        //Animate weapon menu
        float progress = (Time.time - weaponMenuAnimationStartTime) / weaponMenuAnimationDuration;
        if (progress < 1)
        {
            if (weaponMenuOpened)
            {
                rt.position = new Vector3(1000, -150 + 180* progress, 1100);
            }
            else
            {
                rt.position = new Vector3(1000, 30 - 180 * progress, 1100);
            }
        }else if(weaponMenuAnimationStartTime != -1)
        {
            if (weaponMenuOpened)
            {
                rt.position = new Vector3(1000, 30, 1100);
            }
            else
            {
                rt.position = new Vector3(1000, -150, 1100);
            }
            weaponMenuAnimationStartTime = -1;
        }

        //Toggle weapon menu opening
        if (Input.GetKeyDown(KeyCode.F))
        {
            weaponMenuAnimationStartTime = Time.time;
            if (weaponMenuOpened)
            {
                weaponMenuOpened = !weaponMenuOpened;
            }
            else
            {
                weaponMenuOpened = !weaponMenuOpened;
            }
        }

        //Update coin text
        if (gameState == "playing")
        {
            GameObject.Find("Coins-text").GetComponent<TextMeshProUGUI>().text = "Coins: " + GameObject.Find("Player").GetComponent<PlayerController>().coins;
        }

    }

    public void exitGame()
    {
        Application.Quit();
    }

    public void startGame()
    {

        Debug.Log(GameObject.Find("playing-interface"));


        GameObject.Find("starting-menu").SetActive(false);



        playingInterface.SetActive(true);
        gameState = "playing";
    }

    public void GameOver()
    {
        GameOverScreen.Setup(score);
    }

    public void RestartGame()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public string gameState = "starting";

    bool weaponMenuOpened = false;
    float weaponMenuAnimationStartTime = -1;
    public float weaponMenuAnimationDuration = 1; //Duration in seconds
    RectTransform rt;
    GameObject playingInterface;

    public int score = 0;
    public GameOverScreen GameOverScreen;
    public List<GameObject> weaponsButtonList;
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
        if (Input.GetKeyDown(KeyCode.F) || (Input.GetKeyDown(KeyCode.Escape) && weaponMenuOpened))
        {
            weaponMenuAnimationStartTime = Time.time;
            if (weaponMenuOpened)
            {
                weaponMenuOpened = !weaponMenuOpened;
                for(int i = 0; i < weaponsButtonList.Count; i++)
                {
                    weaponsButtonList[i].GetComponent<Button>().interactable = false;
                }
            }
            else
            {
                weaponMenuOpened = !weaponMenuOpened;
                for (int i = 0; i < weaponsButtonList.Count; i++)
                {
                    weaponsButtonList[i].GetComponent<Button>().interactable = true;
                }
            }
        }

        //Update coin text
        if (gameState == "playing")
        {
            GameObject.Find("Coins-text1").GetComponent<TextMeshProUGUI>().text = "Coins: " + GameObject.Find("Player").GetComponent<PlayerController>().coins;
        }

        //Update wave text
        if (gameState == "playing")
        {
            GameObject.Find("Wave-text").GetComponent<TextMeshProUGUI>().text = "Wave: " + GameObject.Find("WaveSpawner").GetComponent<WaveSpawner>().currWave;
        }

    }

    public void exitGame()
    {
        Application.Quit();
    }

    public void startGame()
    {

        //Debug.Log(GameObject.Find("playing-interface"));


        GameObject.Find("starting-menu").SetActive(false);



        playingInterface.SetActive(true);
        gameState = "playing";
    }

    public void GameOver()
    {
        GameOverScreen.Setup(score);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("SampleScene");
    }
}

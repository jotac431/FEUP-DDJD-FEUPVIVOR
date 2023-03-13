using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOverScreen : MonoBehaviour
{
    public TextMeshProUGUI totalCoinsText;
    public TextMeshProUGUI waveText;

    public void Setup(int score)
    {
        gameObject.SetActive(true);
        totalCoinsText.text = score.ToString() + " Coins";

        int wave = GameObject.Find("WaveSpawner").GetComponent<WaveSpawner>().currWave;
        if (wave < 1)
        {
            waveText.text = wave.ToString() + " Wave";
        }
        else
        {
            waveText.text = wave.ToString() + " Wave";
        }
    }
}

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
        totalCoinsText.text = score.ToString() + " COINS";
        waveText.text = score.ToString() + " WAVES";
    }
}

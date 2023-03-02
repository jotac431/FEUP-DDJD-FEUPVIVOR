using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject player;

    [SerializeField]
    private TextMeshProUGUI waveCountText;

    private int WaveCount;
    private int enemyCount;
    private float waveTextTimer = 1.0f;
    private float spawnRate = 1.0f;
    private float timesBetweenWaves = 5.0f;

    [SerializeField]
    private bool _isWaveActive = true;
    private bool _stopSpawning = false;

    IEnumerator waveSpawner()
    {
        while (_isWaveActive == true && _stopSpawning == false)
        {
            //Vector3 spawnPos = new Vector3(Random.Range(-9.3f, 9.3f), 7f, 0f);
            Vector3 spawnPos = new Vector3(0f, 0f, 0f);
            int randomEnemy = 0;
            _isWaveActive = false;


            for (int i = 0; i < enemyCount; i++)
            {
                ActivateWaveText();
                yield return new WaitForSeconds(waveTextTimer);
                waveCountText.gameObject.SetActive(false);

                GameObject enemyClone = Instantiate(enemies[randomEnemy], spawnPos, Quaternion.identity);
                yield return new WaitForSeconds(spawnRate);

                if (WaveCount >= 5)
                {
                    EndEnemyWaves();
                    yield return new WaitForSeconds(3f);
                    Debug.Log("Final Wave! Enter Boss Fight!");
                    //SceneManager.LoadScene(2);
                }
            }

            spawnRate -= 1.0f;
            enemyCount += 1;
            yield return new WaitForSeconds(timesBetweenWaves);
            WaveCount += 1;
            _isWaveActive = true;
        }
    }

    private void ActivateWaveText()
    {
        waveCountText.text = "Wave: " + WaveCount.ToString();
        waveCountText.gameObject.SetActive(true);
    }

    public void EndEnemyWaves()
    {
        _stopSpawning = true;
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            GameObject.Destroy(enemy);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(waveSpawner());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

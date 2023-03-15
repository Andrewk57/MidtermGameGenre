using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class enemySpawner : MonoBehaviour
{
    public GameObject spawnPoint1;
    public GameObject prefabSword;
    public GameObject prefabHorse;
    public float spawnInterval = 1f;
    public int enemiesPerWave = 9;
    public int waves = 2;
    private int enemiesSpawned = 0;
    private int waveNumber = 0;
    public TextMeshProUGUI wave;
    public GameObject VictoryScreen;

    void Start()
    {
        VictoryScreen.SetActive(false);
        Time.timeScale = 1f;
        AudioListener.volume = 1f;
        StartCoroutine(SpawnWave());
        Debug.Log("Wave started");
    }

    IEnumerator SpawnWave()
    {
        waveNumber++;
        wave.text = waveNumber.ToString();
        enemiesSpawned = 0;
        while (enemiesSpawned < enemiesPerWave)
        {
            GameObject prefabToSpawn = Random.value < 0.5f ? prefabSword : prefabHorse;
            Vector3 spawnPosition = spawnPoint1.transform.position;
            Quaternion spawnRotation = prefabToSpawn.transform.rotation * Quaternion.Euler(0, 180f, 0f);
            Instantiate(prefabToSpawn, spawnPosition, spawnRotation);
            enemiesSpawned++;
            yield return new WaitForSeconds(spawnInterval);
        }
        if (waveNumber < waves)
        {
            yield return new WaitForSeconds(20f);
            StartCoroutine(SpawnWave());
        }
        else
        {
            VictoryScreen.SetActive(true);
            AudioListener.volume = 0f;
            Time.timeScale = 0f;

        }
    }
}
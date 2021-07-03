using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform spwanPoint;

    public float timeBetweenWaves = 5f;
    private float countdown = 2f;

    public Text waveCountdownText;

    private int waveNumber = 1;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;

        }

        countdown -= Time.deltaTime;
        waveCountdownText.text = Mathf.Round(countdown).ToString();

    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spwanPoint.position, spwanPoint.rotation);
    }

    IEnumerator SpawnWave()
    {
        print("Wave Incoming!");
        waveNumber++;
        for (var i = 0; i < waveNumber; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
    }
}

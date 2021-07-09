using System.Collections;
 using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public static int EnemiesAlive = 0;
    public Transform spwanPoint;
    public float timeBetweenWaves = 5f;
    public Text waveCountdownText;

    public Wave[] waves;

    private int waveIndex = 0;
    private float countdown = 2f;

    // Start is called before the first frame update
    void Start()
    {

    }

    /// <summary>
    /// This function is called when the object becomes enabled and active.
    /// </summary>
    void OnEnable()
    {
        EnemiesAlive = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (EnemiesAlive > 0) { return; }

        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return;
        }

        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0, Mathf.Infinity);
        waveCountdownText.text = string.Format("{0:00.00}", countdown);
        
    }

    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spwanPoint.position, spwanPoint.rotation);
        EnemiesAlive++;
    }

    IEnumerator SpawnWave()
    {
        print("Wave Incoming!");
        PlayerStats.rounds++;
        Wave wave = waves[waveIndex];

        for (var i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.rate);
        }
        waveIndex++;

        if(waveIndex == waves.Length)
        {
            Debug.Log("Level won !");
            this.enabled = false;
        }
        
    }
}

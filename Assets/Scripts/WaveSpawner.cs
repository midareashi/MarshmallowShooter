using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public PlayerController pc;
    public static GameObject[] enemies;
    private int waveValue;
    public List<GameObject> enemiesToSpawn;
    public int wavePointsMultiplier;
    public int wavePointsAdder;
    public GameObject winScreen;

    public int waveGainedGold;
    public int waveGainedPoints;

    public Transform spawnLocation;

    public float spawnInterval; // Time Between Spawns
    private float spawnTimer;

    public List<GameObject> spawnedEnemies;

    public GameObject spawningEnemy;
    public int spawningEnemyCount = 0;
    public float lastSpawn = 0.0f;

    private bool stageIsActive;

    void Start()
    {
        stageIsActive = false;
        if (MainManager.Instance.currentWave == 0)
        {
            MainManager.Instance.currentWave = 1;
        }
        GenerateWave();
        stageIsActive = true;
    }

    void FixedUpdate()
    {
        if (stageIsActive)
        {
            if (spawnTimer <= 0) // Time to Spawn
            {
                // Spawn an enemy
                if (enemiesToSpawn.Count > 0)
                {
                    spawningEnemy = enemiesToSpawn[0]; // Add enemy to Spawn queue
                    enemiesToSpawn.RemoveAt(0); // Remove it from the list
                    
                    int spawnPos = spawningEnemy.GetComponent<Enemy>().spawnPoints.Count();
                    int randomSpawn = Random.Range(0,spawnPos);
                    spawnLocation = spawningEnemy.GetComponent<Enemy>().spawnPoints[randomSpawn].transform; // Pick a random spawn point
                    spawnTimer = spawnInterval;
                }
            }
            else
            {
                spawnTimer -= Time.fixedDeltaTime;
            }

            if (enemiesToSpawn.Count <= 0 && spawnedEnemies.Count <= 0 && spawningEnemy == null) // No enemies to spawn and no enemies spawned
            {
                stageIsActive = false;
                EndWave("win");
                return;
            }

            if (spawningEnemy != null)
            {
                SpawnEnemy();
            }
        }
    }

    public void GenerateWave()
    {
        waveValue = (MainManager.Instance.currentWave * wavePointsMultiplier) + wavePointsAdder; // How many points to give for each wave
        GenerateEnemies();
    }

    public void GenerateEnemies()
    {
        List<GameObject> generatedEnemies = new List<GameObject>();
        while (waveValue > 0 || generatedEnemies.Count < 50)
        {
            int randEnemyId = Random.Range(0, enemies.Length);
            int randEnemyCost = enemies[randEnemyId].GetComponent<Enemy>().cost;
            int randEnemyStartWave = enemies[randEnemyId].GetComponent<Enemy>().showInWave;

            if (waveValue - randEnemyCost >= 0 && randEnemyStartWave <= MainManager.Instance.currentWave)
            {
                generatedEnemies.Add(enemies[randEnemyId].GetComponent<Enemy>().gameObject);
                waveValue -= randEnemyCost;
            }
            else if (waveValue <= 0)
            {
                break;
            }
        }
        enemiesToSpawn = generatedEnemies;
    }

    public void SpawnEnemy()
    {
        if (Time.time > spawningEnemy.GetComponent<Enemy>().spawnSpeed + lastSpawn)
        {
            if (spawningEnemyCount < spawningEnemy.GetComponent<Enemy>().spawnGroup)
            {
                GameObject enemy = Instantiate(spawningEnemy, spawnLocation.position, Quaternion.identity);
                enemy.GetComponent<Enemy>().spawnTime = Time.time;
                enemy.SetActive(true);
                spawnedEnemies.Add(enemy);
                spawningEnemyCount ++;
                lastSpawn = Time.time;
            }
            else
            {
                spawningEnemy = null;
                spawningEnemyCount = 0;
                lastSpawn = 0;
            }
        }
    }

    public void EndWave(string outcome)
    {
        if (outcome == "win")
        {
            MainManager.Instance.currentWave++;
            MainManager.Instance.currentGold += waveGainedGold;
            MainManager.Instance.currentPoints += waveGainedPoints;
            pc.FlyOffScreen();
            winScreen.SetActive(true);
        }

        if (outcome == "lose")
        {

        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI.Table;

public class WaveSpawner : MonoBehaviour
{
    public static List<EnemyToSpawn> enemies = new List<EnemyToSpawn>();
    private int waveValue;
    public List<GameObject> enemiesToSpawn = new List<GameObject>();

    public Transform spawnLocation;

    public int waveDuration;
    private float waveTimer;
    private float spawnInterval;
    private float spawnTimer;

    public List<GameObject> spawnedEnemies = new List<GameObject>();

    public GameObject spawningEnemy;
    public int spawningEnemyCount = 0;
    public float lastSpawn = 0.0f;
    private float spawnPosition;

    public float stageStartPoints;

    private bool stageIsActive;
    int totalEnemies;


    void Start()
    {
        stageStartPoints = MainManager.Instance.currentPoints;
        GenerateWave();
        stageIsActive = true;
    }

    void FixedUpdate()
    {
        if (stageIsActive)
        {
            if (spawnTimer <= 0) // Time to Spawn
            {
                //spawn an enemy
                if (enemiesToSpawn.Count > 0)
                {
                    spawningEnemy = enemiesToSpawn[0];
                    spawnPosition = Random.Range(-5.0f,5.0f);

                    enemiesToSpawn.RemoveAt(0); // and remove it
                    spawnTimer = spawnInterval;
                }
                else
                {
                    waveTimer = 0; // if no enemies remain, end wave
                }
            }
            else
            {
                spawnTimer -= Time.fixedDeltaTime;
                waveTimer -= Time.fixedDeltaTime;
            }

            if (waveTimer <= 0 && spawnedEnemies.Count <= 0)
            {
                stageIsActive = false;
                EndWave("win");
                //GenerateWave();
            }

            SpawnEnemy();
        }
    }

    public void GenerateWave()
    {
        waveValue = (MainManager.Instance.currentWave * 5) + 5; // How many points to give for each wave
        GenerateEnemies();

        spawnInterval = waveDuration / enemiesToSpawn.Count; // gives a fixed time between each enemies
        waveTimer = waveDuration; // wave duration is read only
    }

    public void GenerateEnemies()
    {
        List<GameObject> generatedEnemies = new List<GameObject>();
        while (waveValue > 0 || generatedEnemies.Count < 50)
        {
            int randEnemyId = Random.Range(0, enemies.Count);
            int randEnemyCost = enemies[randEnemyId].cost;

            if (waveValue - randEnemyCost >= 0)
            {
                generatedEnemies.Add(enemies[randEnemyId].enemyPrefab);
                waveValue -= randEnemyCost;
            }
            else if (waveValue <= 0)
            {
                break;
            }
        }
        enemiesToSpawn.Clear();
        enemiesToSpawn = generatedEnemies;
    }

    public void SpawnEnemy()
    {
        if (spawningEnemy != null) 
        {
            if (Time.time > spawningEnemy.GetComponent<Enemy>().spawnSpeed + lastSpawn)
            {
                if (spawningEnemyCount < spawningEnemy.GetComponent<Enemy>().spawnGroup)
                {
                    GameObject enemy = Instantiate(spawningEnemy, spawnLocation.position + Vector3.left * spawnPosition, Quaternion.identity);
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
    }

    public static void EndWave(string outcome)
    {
        var pc = new PlayerController();
        if (outcome == "win")
        {
            MainManager.Instance.currentWave++;
            pc.FlyOffScreen();
        }

        if (outcome == "lose")
        {

        }
        /*
        
        ShowStoreButton();
        ShowContinuteButton();
        */
    }
}

[System.Serializable]
public class EnemyToSpawn
{
    public GameObject enemyPrefab;
    public int cost;
}
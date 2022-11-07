using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public PlayerController santa;
    [SerializeField] public MapScreenManager msm;

    public static GameObject[] enemies;
    public static GameObject[] bosses;
    private GameObject enemy;
    private GameObject boss;
    private float bossZR;
    public GameObject bossManager;

    private int waveValue;
    public List<GameObject> enemiesToSpawn;
    public int wavePointsMultiplier;
    public int wavePointsAdder;
    [SerializeField] public int bossWaveInterval;

    public int waveGainedGold;
    public int waveGainedPoints;

    private Transform spawnLocation;

    public float spawnInterval; // Time Between Spawns
    private float spawnTimer;

    // Start stage after initial wait
    public float stageStartWaitTime;
    private float stageStartTime;

    public List<GameObject> spawnedEnemies;

    public GameObject spawningEnemy;
    private int spawningEnemyCount;
    private float lastSpawn;

    private bool enemiesAreLoaded;
    private bool stageIsReady;
    private bool bossIsReady;
    private bool moveBossToPosition;

    void Start()
    {
        NextWave();
    }

    public void NextWave()
    {
        if (GameManager.currentWave == 0)
        {
            GameManager.currentWave = 1;
        }
        santa.FlyToStart();
        stageStartTime = Time.time;
        enemiesAreLoaded = false;
        GenerateWave();
    }

    void FixedUpdate()
    {
        WaitToStart();
        if (enemiesAreLoaded && stageIsReady)
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
                enemiesAreLoaded = false;
                EndWave("win");
                return;
            }

            if (spawningEnemy != null)
            {
                SpawnEnemy();
            }
        }
        if (bossIsReady)
        {
            PlayerWeapon.canShoot = false;
            int bossCount = bosses.Length - 1;
            int bossSpawn = Random.Range(0,bossCount);
            boss = Instantiate(bosses[bossSpawn], bosses[bossSpawn].GetComponent<Boss>().spawnLocation.transform.position, Quaternion.identity);
            boss.SetActive(true);
            bossZR = boss.GetComponent<Boss>().zigzagRate;
            boss.GetComponent<Boss>().zigzagRate = 0;
            moveBossToPosition = true;

            bossIsReady = false;
        }

        if (moveBossToPosition)
        {
            boss.transform.position = Vector3.MoveTowards(transform.position, new Vector3(0, 20, 0), 0.2f);
            if (boss.transform.position == Vector3.MoveTowards(transform.position, new Vector3(0, 20, 0), 0.2f))
            {
                moveBossToPosition = false;
                PlayerWeapon.canShoot = true;
                boss.GetComponent<Boss>().zigzagRate = bossZR;
            }
        }
    }

    public void GenerateWave()
    {
        waveValue = (GameManager.currentWave * wavePointsMultiplier) + wavePointsAdder; // How many points to give for each wave
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

            if (waveValue - randEnemyCost >= 0 && randEnemyStartWave <= GameManager.currentWave)
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
        enemiesAreLoaded = true;
    }

    public void SpawnEnemy()
    {
        if (Time.time > spawningEnemy.GetComponent<Enemy>().spawnSpeed + lastSpawn)
        {
            if (spawningEnemyCount < spawningEnemy.GetComponent<Enemy>().spawnGroup)
            {
                enemy = Instantiate(spawningEnemy, spawnLocation.position, Quaternion.identity);
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
            if (GameManager.currentWave % bossWaveInterval == 0)
            {
                SpawnBoss();
            }
            else
            {
                GameManager.currentWave++;
                GameManager.currentGold += waveGainedGold;
                GameManager.currentPoints += waveGainedPoints;
            }
            msm.ShowWinScreen();
        }
        if (outcome == "boss")
        {
        }
        if (outcome == "lose")
        {

        }
    }

    private void SpawnBoss()
    {
        bossIsReady = Time.time >= stageStartTime + stageStartWaitTime;
    }

    private void WaitToStart()
    {
        stageIsReady = Time.time >= stageStartTime + stageStartWaitTime;
    }
}
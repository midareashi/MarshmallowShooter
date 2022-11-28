using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public GameObject mapScreenManager;

    private GameObject enemy;
    private GameObject boss;

    private int waveValue;
    public List<GameObject> enemiesToSpawn;
    public int wavePointsMultiplier;
    public int wavePointsAdder;
    public int bossWaveInterval;

    public float waveGainedPoints;

    private Transform spawnLocation;

    public float spawnInterval; // Time Between Spawns
    private float spawnTimer;

    // Start stage after initial wait
    public float stageStartWaitTime;
    private float stageStartTime;

    public List<GameObject> spawnedEnemies;

    private GameObject spawningEnemy;
    private int spawningEnemyCount;
    private float lastSpawn;
    private float rndPosition;

    private bool enemiesAreLoaded;
    private bool stageIsReady;
    private bool moveBossToStart;

    void Awake()
    {
        if (GameManager.currentWave == 0)
        {
            GameManager.currentWave = 1;
        }
    }

    public void NextWave()
    {
        GameManager.canFire = false;
        stageStartTime = Time.time;
        enemiesAreLoaded = false;
        stageIsReady = false;
        GenerateWave();
    }

    void FixedUpdate()
    {
        WaitToStart();
        if (enemiesAreLoaded && stageIsReady)
        {
            GameManager.canFire = true;
            if (spawnTimer <= 0) // Time to Spawn
            {
                // Spawn an enemy
                if (enemiesToSpawn.Count > 0)
                {
                    spawningEnemy = enemiesToSpawn[0]; // Add enemy to Spawn queue
                    enemiesToSpawn.RemoveAt(0); // Remove it from the list
                    
                    int spawnPos = spawningEnemy.GetComponent<Enemy>().spawnPoints.Count();
                    rndPosition = Random.Range(-5f, 5f);
                    int randomSpawn = UnityEngine.Random.Range(0,spawnPos);
                    spawnLocation = spawningEnemy.GetComponent<Enemy>().spawnPoints[randomSpawn]; // Pick a random spawn point
                    spawnTimer = spawnInterval - (GameManager.gameDifficulty * 0.1f);
                    if (spawnTimer < 0.5)
                    {
                        spawnTimer = 0.5f;
                    }
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

        if (moveBossToStart)
        {
            boss.transform.position = Vector3.MoveTowards(boss.transform.position, boss.GetComponent<Boss>().moveToLocation.transform.position, 5f * Time.fixedDeltaTime);
            if (boss.transform.position == boss.GetComponent<Boss>().moveToLocation.transform.position)
            {
                moveBossToStart = false;
                GameManager.canFire = true;
                Boss.beginFight = true;
            }
        }
    }

    public void GenerateWave()
    {
        waveValue = (GameManager.currentWave * wavePointsMultiplier) + wavePointsAdder; // How many points to give for each wave

        List<GameObject> generatedEnemies = new List<GameObject>();
        while (waveValue > 0 || generatedEnemies.Count < 50)
        {
            int randEnemyId = UnityEngine.Random.Range(0, GameManager.allEnemies.Count);
            int randEnemyCost = GameManager.allEnemies[randEnemyId].GetComponent<Enemy>().cost;
            int randEnemyStartWave = GameManager.allEnemies[randEnemyId].GetComponent<Enemy>().showInWave;

            if (waveValue - randEnemyCost >= 0 && randEnemyStartWave <= GameManager.currentWave)
            {
                generatedEnemies.Add(GameManager.allEnemies[randEnemyId].GetComponent<Enemy>().gameObject);
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
            if (spawningEnemy.GetComponent<Enemy>().spawnTogether) {
                if (spawningEnemyCount < spawningEnemy.GetComponent<Enemy>().spawnGroup)
                {
                    enemy = Instantiate(spawningEnemy, spawnLocation.position + new Vector3(rndPosition, 0, 0), Quaternion.identity);
                    enemy.GetComponent<Enemy>().spawnTime = Time.time;
                    enemy.GetComponent<Enemy>().points = (enemy.GetComponent<Enemy>().cost * GameManager.pointMultiplier) / enemy.GetComponent<Enemy>().spawnGroup;
                    enemy.GetComponent<Vitals>().currentHealth = enemy.GetComponent<Vitals>().maxHealth + (GameManager.gameDifficulty);
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
            else
            {
                foreach(Transform sp in spawningEnemy.GetComponent<Enemy>().spawnPoints) {
                    enemy = Instantiate(spawningEnemy, sp.position + new Vector3(rndPosition, 0, 0), Quaternion.identity);
                    enemy.GetComponent<Enemy>().points = (enemy.GetComponent<Enemy>().cost * GameManager.pointMultiplier) / spawningEnemy.GetComponent<Enemy>().spawnPoints.Count;
                    enemy.GetComponent<Vitals>().currentHealth = enemy.GetComponent<Vitals>().maxHealth + (GameManager.gameDifficulty);
                    enemy.GetComponent<Enemy>().spawnTime = Time.time;
                    enemy.SetActive(true);
                    spawnedEnemies.Add(enemy);
                }
                spawningEnemy = null;
                spawningEnemyCount = 0;
                lastSpawn = 0;
            }
        }
    }

    private void SpawnBoss()
    {
        int bossCount = GameManager.allBosses.Count;
        if (GameManager.bossSpawnCount > bossCount - 1)
        {
            GameManager.bossSpawnCount = 0;
        }
        var spawnBoss = GameManager.allBosses[GameManager.bossSpawnCount];
        var loc = spawnBoss.GetComponent<Boss>().spawnLocation.transform.position;
        boss = Instantiate(spawnBoss, loc, Quaternion.identity);
        boss.SetActive(true);
        boss.GetComponent<Vitals>().currentHealth = boss.GetComponent<Vitals>().maxHealth + (GameManager.gameDifficulty * 5);
        moveBossToStart = true;
        Boss.beginFight = false;
        GameManager.canFire = false;
        GameManager.bossSpawnCount ++;
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
                WinScreen();
            }
        }

        if (outcome == "boss")
        {
            GameManager.gameDifficulty ++;
            WinScreen();
        }

        if (outcome == "lose")
        {
            mapScreenManager.GetComponent<WebPost>().UpdateScore();
            mapScreenManager.GetComponent<MapScreenManager>().ShowLoseScreen();
        }
    }

    private void WinScreen()
    {
        mapScreenManager.GetComponent<MapScreenManager>().ShowWinScreen();
        GameManager.currentWave++;
        GameManager.currentPoints += waveGainedPoints;
    }

    private void WaitToStart()
    {
        stageIsReady = Time.time >= stageStartTime + stageStartWaitTime;
    }
}
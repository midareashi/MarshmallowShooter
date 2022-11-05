using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject enemyHolder;
    public GameObject[] allEnemies;

    private void Awake()
    {
        WaveSpawner.enemies = BuildEnemyList();
    }

    public GameObject[] BuildEnemyList()
    {
        int totalEnemies = enemyHolder.transform.childCount;
        GameObject[] allEnemies = new GameObject[totalEnemies];
        SpawnManager sm = new SpawnManager();

        for (int i = 0; i < totalEnemies; i++)
        {
            allEnemies[i] = enemyHolder.transform.GetChild(i).gameObject;
        }

        foreach (GameObject enemy in allEnemies)
        {
            sm.BuildSpawnList(enemy);
        }

        return allEnemies;
    }
}

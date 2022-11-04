using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject enemyHolder;
    public List<EnemyToSpawn> allEnemies;

    private void Awake()
    {
        WaveSpawner.enemies =  BuildEnemyList();
    }

    public List<EnemyToSpawn> BuildEnemyList()
    {
        int totalEnemies = enemyHolder.transform.childCount;
        List<EnemyToSpawn> allEnemies = new List<EnemyToSpawn>();

        for (int i = 0; i < totalEnemies; i++)
        {
            EnemyToSpawn e = new EnemyToSpawn();
            e.enemyPrefab = enemyHolder.transform.GetChild(i).gameObject;
            e.cost = enemyHolder.transform.GetChild(i).gameObject.GetComponent<Enemy>().cost;
            allEnemies.Add(e);
        }

        return allEnemies;
    }
}

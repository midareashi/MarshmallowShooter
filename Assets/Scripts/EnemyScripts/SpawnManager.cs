using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject spawnHolder;
    int totalSpawnPoints = 1;
    public GameObject[] spawnPoints;

    public static void BuildSpawnList(GameObject enemy)
    {
        SpawnManager sm = new SpawnManager();
        sm.spawnHolder = enemy.GetComponent<Enemy>().spawnHolder.GetComponent<SpawnManager>().gameObject;

        sm.totalSpawnPoints = sm.spawnHolder.transform.childCount;
        sm.spawnPoints = new GameObject[sm.totalSpawnPoints];

        for (int i = 0; i < sm.totalSpawnPoints; i++)
        {
            sm.spawnPoints[i] = sm.spawnHolder.transform.GetChild(i).gameObject;
        }
        enemy.GetComponent<Enemy>().spawnPoints = sm.spawnPoints;
    }
}

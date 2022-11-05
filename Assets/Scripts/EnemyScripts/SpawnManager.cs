using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject spawnHolder;
    int totalSpawnPoints = 1;
    public GameObject[] spawnPoints;

    public void BuildSpawnList(GameObject enemy)
    {
        spawnHolder = enemy.GetComponent<Enemy>().spawnHolder.GetComponent<SpawnManager>().gameObject;

        totalSpawnPoints = spawnHolder.transform.childCount;
        spawnPoints = new GameObject[totalSpawnPoints];

        for (int i = 0; i < totalSpawnPoints; i++)
        {
            spawnPoints[i] = spawnHolder.transform.GetChild(i).gameObject;
        }
        enemy.GetComponent<Enemy>().spawnPoints = spawnPoints;
    }
}

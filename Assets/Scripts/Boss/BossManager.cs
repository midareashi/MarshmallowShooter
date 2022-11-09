using UnityEngine;

public class BossManager : MonoBehaviour
{
    public GameObject bossHolder;
    public GameObject[] allBosses;
    public int bossSpawnInteger;
    public GameObject waveSpawner;

    private void Awake()
    {
        waveSpawner.GetComponent<WaveSpawner>().bosses = BuildBossList();
    }

    public GameObject[] BuildBossList()
    {
        int totalBosses = bossHolder.transform.childCount;
        GameObject[] allBosses = new GameObject[totalBosses];
        SpawnManager sm = new SpawnManager();

        for (int i = 0; i < totalBosses; i++)
        {
            allBosses[i] = bossHolder.transform.GetChild(i).gameObject;
        }

        return allBosses;
    }
}

using UnityEngine;

public class BonusSpawnHolder : MonoBehaviour
{
    public GameObject[] BuildBonusSpawnList()
    {
        int totalBonuses = transform.childCount;
        GameObject[] allBonuses = new GameObject[totalBonuses];
        SpawnManager sm = new SpawnManager();

        for (int i = 0; i < totalBonuses; i++)
        {
            allBonuses[i] = transform.GetChild(i).gameObject;
        }

        return allBonuses;
    }
}

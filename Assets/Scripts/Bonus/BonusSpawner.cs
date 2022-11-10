using UnityEngine;

public class BonusSpawner : MonoBehaviour
{
    public GameObject bonusItem;
    public GameObject bonusSpawnPoints;
    public float bonusSpawnRate;
    public float lastBonusSpawn;
    public Vector2 bonusSpeed;

    public int healthBonus;
    public float speedBonus;
    public int damageBonus;
    public float rofBonus;
    private GameObject[] bonusSpawns;
    private int rndBonus;
    private int rndSpawn;
    private GameObject bonus;

    void Start()
    {
        bonusSpawns = bonusSpawnPoints.GetComponent<BonusSpawnHolder>().BuildBonusSpawnList();
    }

    private void Update()
    {
        if (Time.time >= lastBonusSpawn + bonusSpawnRate)
        {
            rndSpawn = Random.Range(0, bonusSpawns.Length - 1);
            rndBonus = Random.Range(1, 3);

            bonus = Instantiate(bonusItem, bonusSpawns[rndSpawn].transform.position, bonusSpawns[rndSpawn].transform.rotation);
            bonus.SetActive(true);
            bonus.GetComponent<BonusItem>().GetComponent<Rigidbody2D>().velocity = bonusSpeed;

            switch (rndBonus)
            {
                case 1:
                    bonus.GetComponent<BonusItem>().healthBonus = healthBonus;
                    break;
                case 2:
                    bonus.GetComponent<BonusItem>().speedBonus = speedBonus;
                    break;
                case 3:
                    bonus.GetComponent<BonusItem>().damageBonus = damageBonus;
                    break;
            }
            lastBonusSpawn = Time.time;
        }
    }
}

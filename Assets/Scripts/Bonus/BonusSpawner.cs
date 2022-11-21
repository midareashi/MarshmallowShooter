using UnityEngine;

public class BonusSpawner : MonoBehaviour
{
    private GameObject bonus;
    public GameObject bonusSpawnPoint;
    public float bonusSpawnRate;
    private float lastBonusSpawn;
    private int rndBonus;
    private float rndPosition;

    private void OnEnable()
    {
        lastBonusSpawn = Time.time;
    }

    private void Update()
    {
        if (Time.time >= lastBonusSpawn + bonusSpawnRate)
        {
            rndBonus = Random.Range(0, GameManager.allBonuses.Count);
            rndPosition = Random.Range(-5f,5f);
            
            bonus = Instantiate(GameManager.allBonuses[rndBonus], bonusSpawnPoint.transform.position + new Vector3(rndPosition, 0, 0), GameManager.allBonuses[rndBonus].transform.rotation);
            bonus.SetActive(true);
            bonus.GetComponent<Bonus>().GetComponent<Rigidbody2D>().velocity = bonus.GetComponent<Bonus>().bonusSpeed;

            lastBonusSpawn = Time.time;
        }
    }
}

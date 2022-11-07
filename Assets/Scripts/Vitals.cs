using Unity.VisualScripting;
using UnityEngine;

public class Vitals : MonoBehaviour
{
    [SerializeField] public int maxHealth;
    public int currentHealth;
    public WaveSpawner ws;

    public void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            if (gameObject.tag == "Enemy")
            {
                ws.waveGainedPoints += gameObject.GetComponent<Enemy>().points;
                ws.waveGainedGold += gameObject.GetComponent<Enemy>().gold;
                Destroy(gameObject);
            }
            if (gameObject.tag == "Boss")
            {
                ws.waveGainedPoints += gameObject.GetComponent<Boss>().points;
                ws.waveGainedGold += gameObject.GetComponent<Boss>().gold;
                Destroy(gameObject);
                ws.EndWave("boss");
            }
            if (gameObject.tag == "Player")
            {
                ws.EndWave("lose");
            }
        }
    }
}

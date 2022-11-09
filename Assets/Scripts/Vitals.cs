using Unity.VisualScripting;
using UnityEngine;

public class Vitals : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    public GameObject waveSpawner;

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
                waveSpawner.GetComponent<WaveSpawner>().waveGainedPoints += gameObject.GetComponent<Enemy>().points;
                waveSpawner.GetComponent<WaveSpawner>().waveGainedGold += gameObject.GetComponent<Enemy>().gold;
                Destroy(gameObject);
            }
            if (gameObject.tag == "Boss")
            {
                waveSpawner.GetComponent<WaveSpawner>().waveGainedPoints += gameObject.GetComponent<Boss>().points;
                waveSpawner.GetComponent<WaveSpawner>().waveGainedGold += gameObject.GetComponent<Boss>().gold;
                Destroy(gameObject);
                waveSpawner.GetComponent<WaveSpawner>().EndWave("boss");
            }
            if (gameObject.tag == "Player")
            {
                waveSpawner.GetComponent<WaveSpawner>().EndWave("lose");
            }
        }
    }
}

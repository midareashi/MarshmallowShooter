using Unity.VisualScripting;
using UnityEngine;

public class Vitals : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    public GameObject waveSpawner;
    public GameObject santa;

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
                GameManager.currentPoints += gameObject.GetComponent<Enemy>().points;
                GameManager.currentGold += gameObject.GetComponent<Enemy>().gold;
                Destroy(gameObject);
            }
            if (gameObject.tag == "Boss")
            {
                GameManager.currentPoints += gameObject.GetComponent<Boss>().points;
                GameManager.currentGold += gameObject.GetComponent<Boss>().gold;
                Destroy(gameObject);
                waveSpawner.GetComponent<WaveSpawner>().EndWave("boss");
            }

            if (GameManager.currentPoints > GameManager.highScore)
            {
                GameManager.highScore = GameManager.currentPoints;
            }

            if (gameObject.tag == "Player")
            {
                waveSpawner.GetComponent<WaveSpawner>().EndWave("lose");
            }
        }
    }
}

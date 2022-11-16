using Unity.VisualScripting;
using UnityEngine;

public class Vitals : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    public GameObject waveSpawner;

    public void Start()
    {
        if (gameObject.tag == "Enemy")
        {
            SetEnemyHealth();
        }
        if (gameObject.tag == "Boss")
        {
            SetBossHealth();
        }
        else
        {
            currentHealth = maxHealth;
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            if (gameObject.tag == "Enemy")
            {
                GameManager.currentPoints += gameObject.GetComponent<Enemy>().points;
                Destroy(gameObject);
            }
            if (gameObject.tag == "Boss")
            {
                GameManager.currentPoints += gameObject.GetComponent<Boss>().points;
                Destroy(gameObject);
                waveSpawner.GetComponent<WaveSpawner>().EndWave("boss");
            }

            if (gameObject.tag == "Player")
            {
                waveSpawner.GetComponent<WaveSpawner>().EndWave("lose");
            }
        }
    }

    private void SetEnemyHealth()
    {
        currentHealth = maxHealth + GameManager.gameDifficulty;
    }

    private void SetBossHealth()
    {
        currentHealth = maxHealth + (GameManager.gameDifficulty * 5);
    }
}

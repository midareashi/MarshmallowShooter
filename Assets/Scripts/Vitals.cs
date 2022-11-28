using UnityEngine;

public class Vitals : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    public GameObject waveSpawner;
    public bool isDie = false;

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

    private void Update()
    {
    }

    public void TakeDamage(int damage)
    {
        if (GameManager.canFire)
        {
            currentHealth -= damage;

            if (currentHealth <= 0)
            {
                isDie = true;
                if (gameObject.tag == "Enemy")
                {
                    GameManager.currentPoints += gameObject.GetComponent<Enemy>().points;
                }
                if (gameObject.tag == "Boss")
                {
                    GameManager.currentPoints += gameObject.GetComponent<Boss>().points;
                }

                if (gameObject.tag == "Player")
                {
                    waveSpawner.GetComponent<WaveSpawner>().EndWave("lose");
                }
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

using UnityEngine;

public class Vitals : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    public GameObject waveSpawner;
    private float dieTime;
    public bool isDie;
    private float startDieTime;

    public void Start()
    {
        dieTime = 1f;
        isDie = false;
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
        if (isDie)
        {
            if (startDieTime + dieTime < Time.time)
            {
                Destroy(gameObject);
            }
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
                startDieTime = Time.time;
                isDie = true;
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
                Handheld.Vibrate();

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

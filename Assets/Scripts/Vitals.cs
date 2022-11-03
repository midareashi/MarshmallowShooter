using Unity.VisualScripting;
using UnityEngine;

public class Vitals : MonoBehaviour
{
    [SerializeField] public int maxHealth;
    public int currentHealth;

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
                MainManager.Instance.currentPoints += gameObject.GetComponent<Enemy>().points;
                MainManager.Instance.currentGold += gameObject.GetComponent<Enemy>().gold;
            }
            Destroy(gameObject, 2f);
        }
    }
}

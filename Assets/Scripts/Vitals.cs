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
            Destroy(gameObject);
        }
    }
}

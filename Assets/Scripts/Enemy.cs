using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 2f;
    private Rigidbody2D rb;
    private Vector2 screenBounds;
    [SerializeField] public float health, maxHealth = 2f;

    //public static event Action<Enemy> OnEnemyKilled;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, -speed);
        screenBounds = GameManager.CameraPosition;
        health = maxHealth;
    }

    void Update()
    {
        if (transform.position.y < -screenBounds.y * 2)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;

        if (health <= 0)
        {
            Destroy(gameObject);
            //OnEnemyKilled?.Invoke(this);
        }
    }
}

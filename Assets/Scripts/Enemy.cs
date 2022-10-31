using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float frequency = 1.0f;
    private float amplitude = 5.0f;
    private float cycleSpeed = 10.0f;

    private Vector3 pos;
    private Vector3 axis;

    private Vector2 screenBounds;
    [SerializeField] public float health, maxHealth = 2f;

    //public static event Action<Enemy> OnEnemyKilled;

    void Start()
    {
        pos = transform.position;
        axis = transform.right;
        screenBounds = GameManager.CameraPosition;
        health = maxHealth;
    }

    void ZigZagMovement()
    {
        pos += Vector3.down * Time.deltaTime * cycleSpeed;
        transform.position = pos + axis * MathF.Sin(Time.time * frequency) * amplitude;
    }

    void Update()
    {
        ZigZagMovement();
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

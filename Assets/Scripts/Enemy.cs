using System;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] public float frequency; // Cycles per Second 1
    [SerializeField] public float amplitude; // Horizontal Distance 5
    [SerializeField] public float cycleSpeed; // ??? 10
    [SerializeField] public float points;

    private Vector3 pos;
    private Vector3 axis;
    public float spawnTime;

    private Vector2 screenBounds;
    [SerializeField] public float maxHealth;
    [SerializeField] public int spawnGroup; // How many enemies spawn per wave
    [SerializeField] public float spawnSpeed; // Delay between enemies spawning 0.5f
    public float currentHealth;

    //public static event Action<Enemy> OnEnemyKilled;

    void Start()
    {
        pos = transform.position;
        axis = transform.right;
        screenBounds = GameManager.CameraPosition;
        currentHealth = maxHealth;
    }

    void ZigZagMovement()
    {
        pos += Vector3.down * Time.deltaTime * cycleSpeed;
        transform.position = pos + axis * MathF.Sin((Time.time - spawnTime) * frequency) * amplitude;
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
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            //OnEnemyKilled?.Invoke(this);
        }
    }
}

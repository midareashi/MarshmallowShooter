using System;
using UnityEngine;
using System.Collections.Generic;

public class Enemy : MonoBehaviour
{
    public float zigzagRate; // How many zig-zags per second
    public float horizontalDistance; // Horizontal Distance 5
    public float verticalSpeed; // Vertical Speed
    public int points; // Points gained when killed
    public int gold; // Gold gained when killed
    public int cost; // Cost of wave in spawner

    public int collisionDamage;
    public List<Transform> spawnPoints;
    public GameObject spawnHolder;
    public GameObject enemy;

    public GameObject santa;

    public int showInWave;
    private Vector3 pos;
    private Vector3 axis;
    public float spawnTime; // Time since last spawn to offset wave function

    private Vector2 cameraPosition;
    public int spawnGroup; // How many enemies spawn per wave
    public float spawnSpeed; // Delay between enemies spawning 0.5f

    void Start()
    {
        pos = transform.position;
        axis = transform.right;
        cameraPosition = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        verticalSpeed += GameManager.gameDifficulty;
    }

    void ZigZagMovement()
    {
        pos += Vector3.down * Time.deltaTime * verticalSpeed;
        transform.position = pos + axis * MathF.Sin((Time.time - spawnTime) * zigzagRate) * horizontalDistance;
    }

    void Update()
    {
        ZigZagMovement();
        if (transform.position.y < -cameraPosition.y * 2)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerController santa))
        {
            santa.GetComponent<Vitals>().TakeDamage(collisionDamage);
            Destroy(gameObject);
        }
    }
}

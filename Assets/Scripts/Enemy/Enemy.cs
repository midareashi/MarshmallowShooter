using System;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] public float zigzagRate; // How many zig-zags per second
    [SerializeField] public float horizontalDistance; // Horizontal Distance 5
    [SerializeField] public float verticalSpeed; // Vertical Speed
    [SerializeField] public int points; // Points gained when killed
    [SerializeField] public int gold; // Gold gained when killed
    [SerializeField] public int cost; // Cost of wave in spawner
    [SerializeField] public GameObject[] spawnPoints;
    [SerializeField] public GameObject spawnHolder;

    [SerializeField] public int showInWave;
    private Vector3 pos;
    private Vector3 axis;
    public float spawnTime; // Time since last spawn to offset wave function

    private Vector2 screenBounds;
    [SerializeField] public int spawnGroup; // How many enemies spawn per wave
    [SerializeField] public float spawnSpeed; // Delay between enemies spawning 0.5f

    void Start()
    {
        pos = transform.position;
        axis = transform.right;
    }

    void ZigZagMovement()
    {
        pos += Vector3.down * Time.deltaTime * verticalSpeed;
        transform.position = pos + axis * MathF.Sin((Time.time - spawnTime) * zigzagRate) * horizontalDistance;
    }

    void Update()
    {
        ZigZagMovement();
        if (transform.position.y < -GameManager.CameraPosition.y * 2)
        {
            Destroy(gameObject); // Destroy off camera
        }
    }
}

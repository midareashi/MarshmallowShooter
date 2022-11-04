using System;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] public float frequency; // Cycles per Second 1
    [SerializeField] public float amplitude; // Horizontal Distance 5
    [SerializeField] public float cycleSpeed; // ??? 10
    [SerializeField] public int points;
    [SerializeField] public int gold;
    [SerializeField] public int cost;

    private Vector3 pos;
    private Vector3 axis;
    public float spawnTime;

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
        pos += Vector3.down * Time.deltaTime * cycleSpeed;
        transform.position = pos + axis * MathF.Sin((Time.time - spawnTime) * frequency) * amplitude;
    }

    void Update()
    {
        ZigZagMovement();
        if (transform.position.y < -GameManager.CameraPosition.y * 2)
        {
            Destroy(gameObject, 2f);
        }
    }
}
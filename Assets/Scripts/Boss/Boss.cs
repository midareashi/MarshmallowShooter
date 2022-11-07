using System;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] public float zigzagRate; // How many zig-zags per second
    [SerializeField] public float horizontalDistance; // Horizontal Distance 5
    [SerializeField] public float verticalSpeed; // Vertical Speed
    [SerializeField] public int points; // Points gained when killed
    [SerializeField] public int gold; // Gold gained when killed
    [SerializeField] public int cost; // Cost of wave in spawner
    [SerializeField] public GameObject spawnLocation;

    private Vector3 pos;
    private Vector3 axis;

    void Start()
    {
        pos = transform.position;
        axis = transform.right;
    }

    void ZigZagMovement()
    {
        pos += Vector3.down * Time.deltaTime * verticalSpeed;
        transform.position = pos + axis * MathF.Sin(Time.time * zigzagRate) * horizontalDistance;
    }

    void Update()
    {
        ZigZagMovement();
    }
}

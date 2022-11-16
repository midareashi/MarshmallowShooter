using System;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public float zigzagRate; // How many zig-zags per second
    public float horizontalDistance; // Horizontal Distance 5
    public float verticalSpeed; // Vertical Speed
    public int points; // Points gained when killed
    public GameObject spawnLocation;
    public GameObject moveToLocation;
    public GameObject boss;
    public int defeatedCount;

    public static bool beginFight;

    private Vector3 pos;
    private Vector3 axis;

    void Start()
    {
        pos = moveToLocation.transform.position;
        axis = moveToLocation.transform.right;
    }

    void ZigZagMovement()
    {
        pos += Vector3.down * Time.deltaTime * verticalSpeed;
        transform.position = pos + axis * MathF.Sin(Time.time * zigzagRate) * horizontalDistance;
    }

    void Update()
    {
        if (beginFight)
        {
            ZigZagMovement();
        }
    }
}

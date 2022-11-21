using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public float zigzagRate; // How many zig-zags per second
    public float horizontalDistance; // Horizontal Distance 5
    public float verticalSpeed; // Vertical Speed
    public float points; // Points gained when killed
    public GameObject spawnLocation;
    public GameObject moveToLocation;
    public GameObject boss;

    private Rigidbody2D rb;

    // Movement
    private bool isBound = false;
    private int moveDirection = 1;
    public static bool beginFight;
    private Vector2 cameraPosition;
    private float objectPadding = 1f;
    private float objectWidth;
    public float moveSpeed;

    private void Start()
    {
        cameraPosition = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        rb = GetComponent<Rigidbody2D>();
        isBound = false;
    }

    void bossMovement()
    {
        if (isBound)
        {
            rb.velocity = new Vector2(moveSpeed * moveDirection,0);
            if (moveDirection > 0)
            {
                if (transform.position.x > cameraPosition.x - objectWidth - objectPadding)
                {
                    moveDirection *= -1;
                }
            }
            if (moveDirection < 0)
            {
                if (transform.position.x < -cameraPosition.x + objectWidth + objectPadding)
                {
                    moveDirection *= -1;
                }
            }
        }
    }

    void Update()
    {
        if (beginFight)
        {
            bossMovement();
            isBound = true;
        }
    }
}

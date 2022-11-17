using System;
using UnityEngine;
using System.Collections.Generic;
using JetBrains.Annotations;

public class Enemy : MonoBehaviour
{
    public int points; // Points gained when killed
    public int cost; // Cost of wave in spawner

    public int collisionDamage;
    public List<Transform> spawnPoints;
    public GameObject spawnHolder;
    public GameObject enemy;

    private GameObject santa;

    // Movement
    public float speed;
    public bool trackSanta;
    public Vector2 santaPosition;

    // Spawn
    public int showInWave;
    public float spawnTime;

    // Death
    private Vector3 dieDirection = new Vector3(-1, 1, 0);
    private float dieSpeed = 1f;
    private Vector3 dieRotate = new Vector3(0, 0, 150);
    private Vector3 dieScale = new Vector3(-0.3f, -0.3f, 0);

    private Vector2 cameraPosition;
    public int spawnGroup; // How many enemies spawn per wave
    public float spawnSpeed; // Delay between enemies spawning 0.5f

    void Start()
    {
        santa = GameObject.FindGameObjectWithTag("Player");
        santaPosition = santa.transform.position;
        cameraPosition = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    void Update()
    {
        if (GetComponent<Vitals>().isDie)
        {
            transform.position += dieDirection * dieSpeed * Time.deltaTime;
            transform.Rotate(dieRotate * Time.deltaTime);
            transform.localScale += dieScale * Time.deltaTime;
        }
        else if (trackSanta)
        {
            transform.position = Vector3.MoveTowards(transform.position, santaPosition * new Vector2(0, 20f), speed * Time.deltaTime);
        }

        if (transform.position.y < -cameraPosition.y * 1.2f || transform.position.y > cameraPosition.y * 3 || transform.localScale.x <= 0)
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

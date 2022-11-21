using UnityEngine;
using System.Collections.Generic;

public class Enemy : MonoBehaviour
{
    public float points; // Points gained when killed
    public int cost; // Cost of wave in spawner

    public int collisionDamage;
    public List<Transform> spawnPoints;
    public GameObject spawnHolder;
    public GameObject enemy;

    private GameObject santa;

    // Movement
    public float speed;
    private bool trackSanta = true;
    public Vector2 santaPosition;
    public float trackDistance;
    public bool spawnTogether;

    // Spawn
    public int showInWave;
    public float spawnTime;

    // Death
    private Vector3 dieDirection = new Vector3(-1, 1, 0);
    private float dieSpeed = 1f;
    private Vector3 dieRotate = new Vector3(0, 0, 150);
    private Vector3 dieScale = new Vector3(-0.3f, -0.3f, 0);
    [SerializeField] private GameObject explosion;

    private Vector2 cameraPosition;
    public int spawnGroup; // How many enemies spawn per wave
    public float spawnSpeed; // Delay between enemies spawning 0.5f

    void Start()
    {
        santa = GameObject.FindGameObjectWithTag("Player");
        cameraPosition = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    void Update()
    {
        if (GetComponent<Vitals>().isDie)
        {
            transform.position += dieDirection * dieSpeed * Time.deltaTime;
            transform.Rotate(dieRotate * Time.deltaTime);
            transform.localScale += dieScale * Time.deltaTime;
            explosion.SetActive(true);
        }
        else if (trackSanta)
        {
            transform.position = Vector3.MoveTowards(transform.position, santa.transform.position, speed * Time.deltaTime);
            if (transform.position.y - santa.transform.position.y < trackDistance)
            {
                trackSanta = false;
                float n = 40f;
                float sx = transform.position.x;
                float sy = transform.position.y;
                float jx = santa.transform.position.x - sx;
                float jy = santa.transform.position.y - sy;
                santaPosition = new Vector2(n * jx + sx, n * jy + sy);
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, santaPosition, speed * Time.deltaTime);
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

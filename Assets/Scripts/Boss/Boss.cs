using UnityEngine;

public class Boss : MonoBehaviour
{
    public float points; // Points gained when killed
    public GameObject spawnLocation;
    public GameObject moveToLocation;
    public GameObject boss;
    public GameObject waveSpawner;

    private Rigidbody2D rb;

    // Movement
    public float moveSpeed;
    private int moveDirection = 1;
    private bool isBound = false;
    public static bool beginFight;
    private Vector2 cameraPosition;
    private float objectPadding = 1f;
    private float objectWidth;
    
    // Death
    private Vector3 dieDirection = new Vector3(-1, 1, 0);
    private float dieSpeed = 1f;
    private Vector3 dieRotate = new Vector3(0, 0, 150);
    private Vector3 dieScale = new Vector3(-0.3f, -0.3f, 0);

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
        if (GetComponent<Vitals>().isDie)
        {
            transform.position += dieDirection * dieSpeed * Time.deltaTime;
            transform.Rotate(dieRotate * Time.deltaTime);
            transform.localScale += dieScale * Time.deltaTime;
            if (transform.localScale.x <= 0)
            {
                waveSpawner.GetComponent<WaveSpawner>().EndWave("boss");
                Destroy(gameObject);
            }
        }
        else if (beginFight)
        {
            bossMovement();
            isBound = true;
        }
    }
}

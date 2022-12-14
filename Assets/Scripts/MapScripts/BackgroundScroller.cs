using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    public BoxCollider2D col;
    public Rigidbody2D rb;
    public DirtTile dt;

    public GameObject waveSpawner;

    private float height;
    private float scrollSpeed = -4f;
    private Vector2 cameraPosition;
    private Vector2 initialPosition;

    private void Awake()
    {
        initialPosition = transform.position;
    }

    void Start()
    {
        col = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();

        height = dt.mapHeight;
        col.enabled = false;

        rb.velocity = new Vector2(0, scrollSpeed);

        cameraPosition = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
    }

    private void OnEnable()
    {
        transform.position = initialPosition;
    }

    void Update()
    {
        if (transform.position.y < -height - (cameraPosition.y - 1))
        {
            rb.velocity = new Vector2(0, 0);
        }
        else
        {
            rb.velocity = new Vector2(0, scrollSpeed);
        }
    }
}

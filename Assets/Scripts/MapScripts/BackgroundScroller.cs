using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    public BoxCollider2D col;
    public Rigidbody2D rb;

    private float height;
    private float scrollSpeed = -4f;

    void Start()
    {
        col = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();

        height = DirtTile.mapHeight;
        col.enabled = false;

        rb.velocity = new Vector2(0, scrollSpeed);
    }

    void Update()
    {
        if (transform.position.y < -height - (GameManager.CameraPosition.y - 1))
        {
            rb.velocity = new Vector2(0, 0);
        }
        else
        {
        }
    }
}
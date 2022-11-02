using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;

    public int damage;
    public Vector2 speed;
    public int avoid;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = speed;
    }

    private void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Vitals>(out Vitals vitals))
        {
            if (vitals.gameObject.layer != avoid)
            {
                vitals.TakeDamage(damage);
                //Destroy(collision.gameObject);
            }
        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}

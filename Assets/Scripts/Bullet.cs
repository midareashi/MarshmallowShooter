using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 40.0f;
    private Rigidbody2D rb;
    public float damage = 1f;
    public Rigidbody2D santa;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Destroy(gameObject);
    }
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Enemy>(out Enemy enemyComponent))
        {
            enemyComponent.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}

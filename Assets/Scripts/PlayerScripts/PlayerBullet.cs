using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public int damage;
    public Vector2 speed;
    public int avoid;

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
                Destroy(gameObject);
            }
        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}

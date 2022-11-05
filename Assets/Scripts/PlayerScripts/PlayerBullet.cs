using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public int damage;
    public Vector2 speed;

    private void Update()
    {
        if (transform.position.y > GameManager.CameraPosition.y * 2)
        {
            Destroy(gameObject); // Destroy off camera
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Vitals>(out Vitals vitals))
        {
            vitals.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}

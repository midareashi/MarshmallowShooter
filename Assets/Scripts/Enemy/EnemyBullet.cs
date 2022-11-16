using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public int damage;
    public Vector2 speed;
    public Vector2 cameraPosition;

    private void Start()
    {
        cameraPosition = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        damage += GameManager.gameDifficulty;
    }

    private void Update()
    {
        if (transform.position.y < (-cameraPosition.y / 2) * 2)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Vitals vitals))
        {
            vitals.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}

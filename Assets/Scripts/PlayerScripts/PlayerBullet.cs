using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public int damage;
    public Vector2 speed;
    public Vector2 CameraPosition;
    public GameObject bullet;

    public void Start()
    {
        CameraPosition = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    private void Update()
    {
        if (transform.position.y > CameraPosition.y)
        {
            Destroy(gameObject); // Destroy off camera
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Vitals>(out Vitals vitals))
        {
            if (!vitals.isDie)
            {
                vitals.TakeDamage(damage);
                Destroy(gameObject);
            }
        }
    }
}

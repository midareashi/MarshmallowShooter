using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    public GameObject firePoint;
    public Vector2 speed;
    public static bool canShoot;

    public float rof;
    private float lastShot = 0.0f;

    private void Awake()
    {
        canShoot = true;
    }

    private void Update()
    {
        Fire();
    }

    private void Fire()
    {
        if (Time.time > rof + lastShot && canShoot)
        {
            GameObject bullet = Instantiate(GameManager.currentBullet, firePoint.transform.position, firePoint.transform.rotation);
            bullet.SetActive(true);
            bullet.GetComponent<PlayerBullet>().GetComponent<Rigidbody2D>().velocity = GameManager.currentBullet.GetComponent<PlayerBullet>().speed;
            bullet.GetComponent<PlayerBullet>().damage = GameManager.currentBullet.GetComponent<PlayerBullet>().damage;
            lastShot = Time.time;
        }
    }
}

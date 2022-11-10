using UnityEngine;

public class BossMissile : MonoBehaviour
{
    public Transform firePoint;
    public GameObject enemyBullet;
    public Vector2 speed;
    public int damage;
    public float delay;
    public float rof;
    private float lastShot;

    private void Start()
    {
        lastShot = delay;
    }

    private void Update()
    {
        Fire();
    }

    private void Fire()
    {
        if (Time.time > rof + lastShot && PlayerWeapon.canShoot)
        {
            GameObject bullet = Instantiate(enemyBullet, firePoint.position, firePoint.rotation);
            bullet.SetActive(true);
            bullet.GetComponent<EnemyBullet>().GetComponent<Rigidbody2D>().velocity = speed;
            bullet.GetComponent<EnemyBullet>().damage = damage;
            lastShot = Time.time;
        }
    }
}

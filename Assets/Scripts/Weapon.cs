using UnityEditor.UIElements;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public Vector2 speed; // 0, 20
    public int damage; // 1
    public int avoid;

    public float fireForce;
    public float rof;
    private float lastShot = 0.0f;

    private void Update()
    {
        Fire();
    }

    public void Fire()
    {
        if (Time.time > rof + lastShot)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            bullet.GetComponent<Bullet>().speed = speed;
            bullet.GetComponent<Bullet>().damage = damage;
            bullet.GetComponent<Bullet>().avoid = avoid;
            lastShot = Time.time;
        }
    }
}

using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireForce = 20f;
    public float rof = 0.1f;
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
            bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);
            lastShot = Time.time;
        }
    }
}

using UnityEngine;

public class PlayerWeaponFirepoint : MonoBehaviour
{
    public GameObject playerWpn;
    public Vector2 baseSpeed;
    public GameObject santa;
    public int baseDamage;
    public float ROF;
    private float lastShot;
    public static bool canShoot;

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
        if (Time.time > ROF + lastShot && canShoot)
        {
            GameObject bullet = Instantiate(GameManager.currentBullet, transform.position, transform.rotation);
            bullet.SetActive(true);
            bullet.GetComponent<PlayerBullet>().GetComponent<Rigidbody2D>().velocity += baseSpeed;
            bullet.GetComponent<PlayerBullet>().damage += baseDamage + santa.GetComponent<PlayerController>().damageBonusTemp;
            lastShot = Time.time;
        }
    }
}

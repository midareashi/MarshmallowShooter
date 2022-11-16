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
    private bool battleStarted;

    private void Start()
    {
        battleStarted = false;
    }

    private void Update()
    {
        if (GameManager.canFire && !battleStarted)
        {
            lastShot = Time.time + delay;
            battleStarted = true;
        }
        Fire();
    }

    private void Fire()
    {
        if (Time.time > rof + lastShot && GameManager.canFire)
        {
            GameObject bullet = Instantiate(enemyBullet, firePoint.position, firePoint.rotation);
            bullet.SetActive(true);
            bullet.GetComponent<EnemyBullet>().GetComponent<Rigidbody2D>().velocity = speed;
            bullet.GetComponent<EnemyBullet>().damage = damage;
            lastShot = Time.time;
        }
    }
}

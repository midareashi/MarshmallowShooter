using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    public GameObject enemyBullet;
    public Vector2 speed;
    public int damage;

    public float rof;
    private float lastShot = 0.0f;

    private void Start()
    {
        rof += GameManager.gameDifficulty;
        damage += GameManager.gameDifficulty;
    }

    private void Update()
    {
        Fire();
    }

    private void Fire()
    {
        if (Time.time > rof + lastShot)
        {
            GameObject bullet = Instantiate(enemyBullet, transform.position, transform.rotation);
            bullet.SetActive(true);
            bullet.GetComponent<EnemyBullet>().GetComponent<Rigidbody2D>().velocity = speed;
            bullet.GetComponent<EnemyBullet>().damage = damage;
            lastShot = Time.time;
        }
    }
}

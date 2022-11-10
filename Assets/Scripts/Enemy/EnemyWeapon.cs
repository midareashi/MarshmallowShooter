using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    public Transform[] firePoints;
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
            foreach (Transform t in firePoints)
            {
                GameObject bullet = Instantiate(enemyBullet, t.position, t.rotation);
                bullet.SetActive(true);
                bullet.GetComponent<EnemyBullet>().GetComponent<Rigidbody2D>().velocity = speed;
                bullet.GetComponent<EnemyBullet>().damage = damage;
            }
            lastShot = Time.time;
        }
    }
}

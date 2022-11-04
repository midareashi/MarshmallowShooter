using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    public Transform[] firePoints;
    public Vector2 speed;

    public int damage;

    public float rof;
    private float lastShot = 0.0f;

    private void Update()
    {
        Fire();
    }

    private void Fire()
    {
        if (Time.time > rof + lastShot)
        {
            foreach (Transform t in MainManager.Instance.currentWeapon.GetComponent<PlayerWeapon>().firePoints)
            {
                GameObject bullet = Instantiate(MainManager.Instance.currentBullet, t.position, t.rotation);
                bullet.SetActive(true);
                bullet.GetComponent<PlayerBullet>().GetComponent<Rigidbody2D>().velocity = MainManager.Instance.currentBullet.GetComponent<PlayerBullet>().speed;
                bullet.GetComponent<PlayerBullet>().damage = MainManager.Instance.currentBullet.GetComponent<PlayerBullet>().damage;
            }
            lastShot = Time.time;
        }
    }
}

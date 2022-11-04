using UnityEditor.UIElements;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform[] firePoints;
    public Vector2 speed; // 0, 20

    public int avoid;
    public int damage;

    public GameObject bulletInstance;

    public float fireForce;
    public float rof;
    private float lastShot = 0.0f;

    private void Start()
    {
        bulletInstance = Instantiate(MainManager.Instance.currentBullet);
    }

    private void Update()
    {
        Fire();
    }

    public void Fire()
    {
        if (Time.time > rof + lastShot)
        {
            foreach (Transform t in firePoints)
            {
                GameObject bullet = Instantiate(bulletInstance, t.position, t.rotation);
                bullet.GetComponent<Bullet>().speed = MainManager.Instance.currentBullet.GetComponent<Bullet>().speed;
                bullet.GetComponent<Bullet>().damage = MainManager.Instance.currentBullet.GetComponent<Bullet>().damage;
                bullet.GetComponent<Bullet>().avoid = avoid;
                bullet.SetActive(true);
            }
            lastShot = Time.time;
        }
    }
}

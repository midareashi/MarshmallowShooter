using UnityEngine;

public class Bonus : MonoBehaviour
{
    public int healthBonus;
    public float speedBonus;
    public int damageBonus;
    public GameObject santa;
    public GameObject bonus;
    private Vector2 cameraPosition;
    public Vector2 bonusSpeed;

    private void Start()
    {
        cameraPosition = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    private void Update()
    {
        if (transform.position.y < (-cameraPosition.y / 2) * 2)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Vitals vitals))
        {
            if (healthBonus > 0)
            {
                santa.GetComponent<Vitals>().currentHealth += healthBonus;
                if (santa.GetComponent<Vitals>().currentHealth > santa.GetComponent<Vitals>().maxHealth)
                {
                    santa.GetComponent<Vitals>().currentHealth = santa.GetComponent<Vitals>().maxHealth;
                }
            }
            santa.GetComponent<PlayerController>().speedBonusTemp = speedBonus;
            santa.GetComponent<PlayerController>().damageBonusTemp = damageBonus;
            santa.GetComponent<PlayerController>().bonusStartTime = Time.time;
            santa.GetComponent<PlayerController>().hasBonus = true;
            Destroy(gameObject);
        }
    }
}

using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public GameObject santa;

    public void Update()
    {
        SetMaxHealth(santa.GetComponent<Vitals>().currentHealth);
    }
    public void SetMaxHealth(float health)
    {
        slider.maxValue = santa.GetComponent<Vitals>().maxHealth;
        slider.value = santa.GetComponent<Vitals>().currentHealth;
        fill.color = gradient.Evaluate(1f);
    }

    public void SetHealth(int health)
    {
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}

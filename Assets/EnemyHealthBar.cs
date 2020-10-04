using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image Fill;

    public void SetMaxHealth(int maxHealth)
    {

        slider.maxValue = maxHealth;

        Fill.color = gradient.Evaluate(1f);

    }

    public void setHealth(int health)
    {
        slider.value = health;
        Fill.color = gradient.Evaluate(slider.normalizedValue);

    }
}

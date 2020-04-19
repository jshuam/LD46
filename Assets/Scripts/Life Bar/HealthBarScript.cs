using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    public Slider slider;

    private float _health = 100;

    public void SetMaxHealth(int health){
        slider.maxValue = health;
        slider.value = health;
    }

    private void SetHealth(int health){
        slider.value = health;
    }

    public void TakeDamage(int damage){
        if(_health - damage < 0){
            _health = 0;
        }
        else {
            _health -= damage;
        }
        slider.value = _health;
    }

    public void HealDamage(float damage){
        if(_health + damage > slider.maxValue){
            _health = slider.maxValue;
        } else {
            _health += damage;
        }
        slider.value = _health;
    }
}

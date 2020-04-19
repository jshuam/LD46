using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private Transform _bar = null;

    [SerializeField]
    private float _health = 0f;

    private void Start()
    {
        _bar.localScale = new Vector3( _health, 1f );
    }

    // Update is called once per frame
    private void Update()
    {
        _bar.localScale = new Vector3( _health, 1f );
    }

    // Set health to specific value
    public void setHealth(float health = 0f){
        _health = health;
    }

    // Subtracts damage as percentage
    public void TakeDamage(int damage){
        // the scale of damage to float is 1% = 0.02f;
        float floatDamage = damage * 0.02f;
        if(_health + floatDamage > 4f){
            _health = 4f;
            return;
        }

        _health += floatDamage;
    }

    public void HealDamage(int damage){
        // the scale of damage to float is 1% = 0.02f;
        float floatDamage = damage * 0.02f;
        if(_health - floatDamage < 0f){
            _health = 0f;
            return;
        }

        _health -= floatDamage;
    }

}

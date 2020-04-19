using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private Transform _bar = null;

    [SerializeField]
    private float _barLength;

    [SerializeField]
    private float _health = 0f;

    [SerializeField]
    public float maxHealth = 100f;

    private void Start()
    {
        _barLength = _bar.localScale.x;
        setHealth( 100f );
        _bar.localScale = new Vector3( _barLength * ( _health / maxHealth ), 1f );
    }

    // Update is called once per frame
    private void Update()
    {
        _bar.localScale = new Vector3( _barLength * ( _health / maxHealth ), 1f );
    }

    // Set health to specific value
    public void setHealth(float health = 0f){
        _health = health;
    }

    // Subtracts damage as percentage
    public void TakeDamage(float damage){
        if(_health - damage < 0f){
            _health = 0f;
            return;
        }

        _health -= damage;
    }

    public void HealDamage(float damage){
        if(_health + damage > maxHealth){
            _health = maxHealth;
            return;
        }

        _health += damage;
    }

}

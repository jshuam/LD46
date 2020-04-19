using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRunner : MonoBehaviour
{
    [SerializeField] private HealthBar healthBar = null;

    // Start
    void Start()
    {
        healthBar.setHealth();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            healthBar.TakeDamage(1);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            healthBar.HealDamage(1);
        }
    }
    
}

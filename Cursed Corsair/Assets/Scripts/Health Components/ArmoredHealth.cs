using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmoredHealth : MonoBehaviour, IHealth
{
    float _totalHealth = 50f;
    float _currentHealth;

    float _totalArmor = 50f;
    float _currentArmor;
    void Start()
    {
        _currentHealth = _totalHealth;
        _currentArmor = _totalArmor;
    }

    public void TakeDamage(float pDamage)
    {
        if (_currentArmor >= 0)
        {
            _currentArmor -= pDamage;
        }
        else
        {
            _currentHealth -= pDamage;
            if (_currentHealth <= 0)
            {
                GetDestroyed();
            }
        }
    }
    public void GetDestroyed()
    {
        Destroy(gameObject);
    }
}

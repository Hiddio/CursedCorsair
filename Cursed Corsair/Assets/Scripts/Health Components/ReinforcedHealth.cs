using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReinforcedHealth : MonoBehaviour, IHealth
{
    float _totalHealth = 50f;
    float _currentHealth;

    float _protectionPercentage = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        _currentHealth = _totalHealth;
    }
    public void TakeDamage(float pDamage)
    {
        float damageReduction = pDamage * _protectionPercentage;
        int roundedProtection = Mathf.CeilToInt(damageReduction);
        float damageAfterProtection = pDamage - roundedProtection;

        _currentHealth -= damageAfterProtection;
        if (_currentHealth <= 0)
        {
            GetDestroyed();
        }
    }

    public void GetDestroyed()
    {
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnarmoredHealth : MonoBehaviour, IHealth
{
    float _totalHealth = 50f;
    float _currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        _currentHealth = _totalHealth;
    }

    public void TakeDamage(float pDamage)
    {
        _currentHealth -= pDamage;
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicShipHealth : MonoBehaviour, IHealth
{
    Rigidbody _rigidBody;

    float _totalHealth = 100f;
    float _currentHealth;

    [SerializeField] Transform _respawnPoint;
    float _respawnRotation = -90f;
    // Start is called before the first frame update
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();

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
        gameObject.transform.position = _respawnPoint.position;
        _rigidBody.MoveRotation(Quaternion.Euler(0, _respawnRotation, 0));
        _currentHealth = _totalHealth;
    }
}

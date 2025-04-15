using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicCannonBallBehaviour : MonoBehaviour
{
    Rigidbody _rigidBody;
    float _projectileSpeed = 50f;
    float _projectileDamage = 10f;
    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }
    void Start()
    {
        //By setting the transform's parent to null, any cannon spawned no longer follows the updating rotation of it's parent
        transform.parent = null;
        Destroy(gameObject, 10);
    }
    void Update()
    {
        Accelerate();
    }

    private void Accelerate()
    {
        Vector3 velocity = transform.forward * _projectileSpeed;

        _rigidBody.velocity = velocity;
    }

    void OnTriggerEnter(Collider collision)
    {
        IHealth ihealth = collision.gameObject.GetComponent<IHealth>();
        if (ihealth != null)
        {
            ihealth.TakeDamage(_projectileDamage);
            Destroy(gameObject);
        }
        else if (collision != null)
        {
            Debug.Log("We hit something, that's for sure");
        }
    }

}

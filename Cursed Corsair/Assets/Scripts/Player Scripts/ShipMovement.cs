using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    Rigidbody _rigidBody;

    float _shipSpeed = 0;
    float _shipAcceleration = 2f;
    float _currentRotation;

    float _currentRotationSpeed;

    [SerializeField, Range(0, 50)] float _maxShipSpeed = 50;

    [SerializeField, Range(5, 20)] float _minRotationSpeed = 20;
    [SerializeField, Range(20, 40)] float _maxRotationSpeed = 40;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
        // transform.eulerAngles shows the degrees of the rotation for any object, while transform.rotation shows the quaternions which is -1 to 1
        _currentRotation = gameObject.transform.eulerAngles.y;
    }

    public void Accelerate()
    {
        _shipSpeed += _shipAcceleration * Time.deltaTime;

        _shipSpeed = Mathf.Clamp(_shipSpeed, 0, _maxShipSpeed);

        float gravity = _rigidBody.velocity.y;

        Vector3 velocity = transform.forward * _shipSpeed;
        velocity.y = gravity;

        _rigidBody.velocity = velocity;
    }

    public void Decelerate()
    {
        _shipSpeed -= _shipAcceleration * Time.deltaTime;

        _shipSpeed = Mathf.Clamp(_shipSpeed, 0, _maxShipSpeed);

        float gravity = _rigidBody.velocity.y;

        Vector3 velocity = transform.forward * _shipSpeed;
        velocity.y = gravity;

        _rigidBody.velocity = velocity;
    }

    public void Rotation(int steerDirection = 0)
    {
        float t = _shipSpeed / _maxShipSpeed;//[0-1.0]
        //float speedT = ;//inverse of t

        //_currentRotationSpeed = Mathf.Lerp(_maxRotationSpeed, _minRotationSpeed, t);
        _currentRotationSpeed = Mathf.Lerp(_minRotationSpeed, _maxRotationSpeed, 1.0f - t);


        //[0-1.0]
        //[0 - _rotationSpeed]
        //[_minRotationSpeed - _maxRotationSpeed]

        _currentRotation += steerDirection * _currentRotationSpeed * Time.deltaTime;

        _rigidBody.MoveRotation(Quaternion.Euler(0, _currentRotation, 0));
        //_rigidBody.AddForceAtPosition(steerDirection * transform.right * _rotationSpeed / 100f, _rudder.position);
    }
}


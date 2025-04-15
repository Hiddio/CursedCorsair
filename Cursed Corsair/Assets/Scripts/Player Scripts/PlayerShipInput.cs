using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShipInput : MonoBehaviour, IInput
{
    ShipMovement _shipMovement;
    List<IFireable> _cannons = new List<IFireable>();

    private float _fireInterval = 1f;
    private float _timer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        _shipMovement = GetComponent<ShipMovement>();
        _cannons.AddRange(GetComponentsInChildren<IFireable>());
    }

    // Update is called once per frame
    void Update()
    {
        ForwardInput();
        RotationInput();
        CannonFiringInput();
    }
    void ForwardInput()
    {
        if(Input.GetKey(KeyCode.W))
        {
            _shipMovement.Accelerate();
        }
        else
        {
            _shipMovement.Decelerate();
        }
    }
    void BrakeInput()
    {
        if(Input.GetKey(KeyCode.S))
        {
            _shipMovement.Decelerate();
        }
    }

    void RotationInput()
    {
        if(Input.GetKey(KeyCode.A))
        {
            _shipMovement.Rotation(-1);
        }
        if(Input.GetKey(KeyCode.D))
        {
            _shipMovement.Rotation(1);
        }
    }

    public void CannonFiringInput()
    { 
        _timer += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_timer >= _fireInterval)
            {
                foreach (IFireable cannon in _cannons)
                {
                    cannon.Fire();
                }
                _timer = 0;
            }
        }
    }
}

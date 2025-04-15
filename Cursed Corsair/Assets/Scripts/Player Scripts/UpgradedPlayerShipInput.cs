using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradedPlayerShipInput : MonoBehaviour
{
    ShipMovement _shipMovement;
    List<IFireable> _cannons = new List<IFireable>();

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
        if (Input.GetKey(KeyCode.W))
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
        if (Input.GetKey(KeyCode.S))
        {
            _shipMovement.Decelerate();
        }
    }

    void RotationInput()
    {
        if (Input.GetKey(KeyCode.A))
        {
            _shipMovement.Rotation(-1);
        }
        if (Input.GetKey(KeyCode.D))
        {
            _shipMovement.Rotation(1);
        }
    }

    public void CannonFiringInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            foreach (IFireable cannon in _cannons)
            {
                cannon.Fire();
            }
        }
    }
}

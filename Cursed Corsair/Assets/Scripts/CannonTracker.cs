using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonTracker : MonoBehaviour
{
    [SerializeField] private GameObject Target;
    [SerializeField] private GameObject CannonObject;
    [SerializeField] private float _detectionRadius = 10f;

    private bool _isFacingTarget;

    public bool IsFacingTarget
    {
        get => _isFacingTarget;
    }

    private void Update()
    {
        RadiusCheck();
    }

    private void FacingTarget()
    {

        CannonObject.transform.LookAt(Target.transform);
    }

    private void RadiusCheck()
    {
        float distance = Vector3.Distance(Target.transform.position, transform.position);
        if (distance <= _detectionRadius)
        {
            _isFacingTarget = true;
            FacingTarget();
        }
        else
        {
            _isFacingTarget = false;
        }
    }
}

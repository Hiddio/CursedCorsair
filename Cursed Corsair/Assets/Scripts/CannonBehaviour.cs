using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CannonBehaviour : MonoBehaviour, IFireable
{
    [SerializeField] GameObject CannonBallPrefab;

    public virtual void Fire()
    {
        Instantiate(CannonBallPrefab, gameObject.transform);
    }
}

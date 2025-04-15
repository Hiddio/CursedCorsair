using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour, IBehaviour
{
    [SerializeField] private CannonTracker _cannonTracker;
    List<IFireable> _cannons = new List<IFireable>();

    private float _fireInterval = 5f;
    private float _timer = 0f;


    // Start is called before the first frame update
    void Start()
    {
        _cannons.AddRange(GetComponentsInChildren<IFireable>());
    }

    // Update is called once per frame
    void Update()
    {
        CannonBehaviour();
    }
    public void CannonBehaviour()
    {
        if (_cannonTracker.IsFacingTarget)
        {
            _timer += Time.deltaTime;
            if (_timer >= _fireInterval)
            {
                foreach (IFireable cannon in _cannons)
                {
                    cannon.Fire();
                }
                _timer = 0f;
            }
        }
    }
}

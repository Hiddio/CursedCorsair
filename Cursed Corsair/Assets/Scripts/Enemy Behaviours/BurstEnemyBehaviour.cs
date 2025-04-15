using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurstEnemyBehaviour : MonoBehaviour, IBehaviour
{
    [SerializeField] private CannonTracker _cannonTracker;
    List<IFireable> _cannons = new List<IFireable>();

    private float _fireInterval = 5f;
    private float _fireDelay = 0.5f;
    private int _shotsToFire = 3;
    private float _timer = 0f;
    private int _shotsFired = 0;
    private bool _firingSequence = false;

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

            if (!_firingSequence && _timer >= _fireInterval)
            {
                _firingSequence = true;
                _shotsFired = 0;
                _timer = 0f;
            }
            if (_firingSequence && _shotsFired < _shotsToFire)
            {
                if (_timer >= _fireDelay * (_shotsFired + 1))
                {
                    foreach (IFireable cannon in _cannons)
                    {
                        cannon.Fire();
                    }
                    _shotsFired++;
                }
            }

            if (_firingSequence && _shotsFired == _shotsToFire)
            {
                _firingSequence = false;
            }
        }
    }
}


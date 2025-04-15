using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DualEnemyBehaviour : MonoBehaviour, IBehaviour
{
    [SerializeField] private CannonTracker _cannonTracker;
    List<IFireable> _cannons = new List<IFireable>();

    private float _fireInterval = 1f;
    private float _timer = 0f;

    private int _currentCannon = 0;

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
                if (_currentCannon == 0)
                {
                    _currentCannon = 1;
                }
                else
                {
                    _currentCannon = 0;
                }
                _cannons[_currentCannon].Fire();
                _timer = 0f;
            }
        }
    }
}

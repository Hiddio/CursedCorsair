using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Windows;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] GameObject _longShotCannons;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpgradePlayerInput()
    {
        Destroy(GetComponent<IInput>() as MonoBehaviour);
        UpgradedPlayerShipInput advancedInput = gameObject.AddComponent<UpgradedPlayerShipInput>();
        advancedInput.enabled = true;
        _longShotCannons.SetActive(true);
    }
}


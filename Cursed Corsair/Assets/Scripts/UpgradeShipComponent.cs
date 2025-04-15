using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeShipComponent : MonoBehaviour
{
    private void Start()
    {
        // Add a trigger collider to the GameObject
        gameObject.AddComponent<BoxCollider>().isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerBehaviour playerBehaviour = other.GetComponent<PlayerBehaviour>();

        // Check if the object touching this is the player
        if (playerBehaviour == null)
        {
            return;
        }

        // Call the UpgradePlayerInput function from PlayerBehaviour
        playerBehaviour.UpgradePlayerInput();

        // Destroy this pickup object
        Destroy(gameObject);
    }

    private void Update()
    {
        Rotator();
    }

    
    private void Rotator()
    {
        // Slowly rotate the object around the X axis continuously
        float rotationSpeed = 20f;

        transform.Rotate(Vector3.right, rotationSpeed * Time.deltaTime);
    }
}

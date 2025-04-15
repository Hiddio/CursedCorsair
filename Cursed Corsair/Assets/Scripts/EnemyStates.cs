using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStates : MonoBehaviour
{
    GameObject chaser;
    GameObject target;
    Ray chaseRay;
    ///EnemyStates
    // - Chasing State
    // - Combat State
    //? - Engaged State and Firing state for Combat?? So player can dodge and all battles aren't just circling around each other and firing???
    //? - Roaming State?? not yet written down

    void ChasingState()
    {
        // When the enemy IS chasing the player
        // The enemy will keep themselves facing the player
        // The enemy will move towards the player
    }



    void CombatState()
    {
        // When the enemy IS engaged in combat with the player
        // The enemy will check if he's in radius of the player
        // The enemy will rotate around the player
        // If their broadside is towards the player, fire all cannons
    }

}

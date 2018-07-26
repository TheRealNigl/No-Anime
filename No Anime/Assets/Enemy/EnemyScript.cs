using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    public Transform player;               // Reference to the player's position.     // Reference to the player's health.      // Reference to this enemy's health.
    NavMeshAgent nav;               // Reference to the nav mesh agent.


    void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
    }


    void Update()
    {

            nav.SetDestination(player.position);

    }
}
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public int difficultyModifier;
    public int LookRadius;
    public Transform Playerpos;
    public Transform Enemypos;
    public Transform Petpos;
    Vector3 baseLocation;
    NavMeshAgent agent;
    Animator animate;
    void Start() {
        // Grab NavMeshAgent and the Animator, and also set the enemy's spawn location
        agent = GetComponent<NavMeshAgent>();
        animate = GetComponent<Animator>();
        baseLocation = transform.position;
    }

    void Update() {
        // Check for look radius
        if (Vector3.Distance(Playerpos.position, Enemypos.position) < LookRadius/* || (Vector3.Distance(Petpos.position, Enemypos.position) < LookRadius)*/) {
            // Set the enemy so that it starts moving towards the player's position (updated every frame)
            agent.SetDestination(Playerpos.position);

            // Play the running animation so it isn't just levitating tgowarsd the player
            animate.Play("RunForward");
        }

        else if (Vector3.Distance(baseLocation, Enemypos.position) > 1.0f) {
            // Make it so the enemy moves back to it's spawn
            agent.SetDestination(baseLocation);
        }

        else {
            // Set the enemy to idle animation when not doing anything
            animate.Play("Idle");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PetMovement : MonoBehaviour
{
    public Transform Playerpos;
    NavMeshAgent agent;
    void Start() {
        // Grab NavMeshAgent
        agent = GetComponent<NavMeshAgent>();
    }

    void Update() {
        // Make the pet hover around the player's location
        agent.destination = Playerpos.position - new Vector3(5,0,5);
    }
}

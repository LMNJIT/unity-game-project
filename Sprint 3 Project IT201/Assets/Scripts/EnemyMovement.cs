using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;


// add bruenian equation or w/e to make them randomly walk around

public class EnemyMovement : MonoBehaviour
{
    public Transform Playerpos;
    // Added Enemypos transform
    public Transform Enemypos;
    // Added Petpos Transform
    public Transform Petpos;
    Vector3 baseLocation;
    NavMeshAgent agent;
    // Start is called before the first frame update
    void Start() {
        agent = GetComponent<NavMeshAgent>();
        baseLocation = Enemypos.position;
    }

    // Update is called once per frame
    void Update() {
        // Added a check for distance between Player and Enemy
        if ((Vector3.Distance(Playerpos.position, Enemypos.position) < 10) || (Vector3.Distance(Petpos.position, Enemypos.position) < 10)) {
            agent.destination = Playerpos.position; 
        }
        else {
            agent.destination = baseLocation;
        }
    }
}

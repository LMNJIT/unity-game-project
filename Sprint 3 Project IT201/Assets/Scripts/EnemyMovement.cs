using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public Transform Playerpos;
    // Added Enemypos transform
    public Transform Enemypos;
    // Added Petpos Transform
    public Transform Petpos;
    NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        // Added a check for distance between Player and Enemy
        if ((Vector3.Distance(Playerpos.position, Enemypos.position) < 50) || (Vector3.Distance(Petpos.position, Enemypos.position) < 50)) 
            agent.destination = Playerpos.position - new Vector3(0,0,0);
    }
}

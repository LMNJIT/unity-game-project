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
    Transform baseLocation;
    NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        baseLocation = transform;
    }

    // Update is called once per frame
    void Update()
    {
        // Added a check for distance between Player and Enemy
        if ((Vector3.Distance(Playerpos.position, Enemypos.position) < 10) || (Vector3.Distance(Petpos.position, Enemypos.position) < 10)) 
            agent.destination = Playerpos.position - new Vector3(0,0,0);
        else if (Vector3.Distance(baseLocation.position, Enemypos.position) > 0.1f)
            agent.destination = baseLocation.position;
        
    }
}

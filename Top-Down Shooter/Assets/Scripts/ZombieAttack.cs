using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class ZombieAttack : MonoBehaviour
{
    public Transform player;
    public NavMeshAgent Agent;

    // Start is called before the first frame update
    void Start()
    {
        Agent = GetComponent<NavMeshAgent>();
        Agent.updateRotation = false;
        Agent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        Agent.SetDestination(player.position);
    }
}

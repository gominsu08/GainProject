using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyTest : MonoBehaviour
{
    [SerializeField] Transform targetTrm;

    NavMeshAgent agent;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }


    private void Update()
    {
        agent.SetDestination(targetTrm.position);
    }
}

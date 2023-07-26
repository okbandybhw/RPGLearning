using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterMovement : MonoBehaviour
{
    NavMeshAgent agent;
    // Start is called before the first frame update
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public void SetDestination(Vector3 destinationPos)
    {
        agent.isStopped = false;
        agent.SetDestination(destinationPos);
    }

    public void Stop()
    {
        if (agent == null)
            return;
        agent.isStopped = true;
    }
}

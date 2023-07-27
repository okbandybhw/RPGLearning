using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Animate : MonoBehaviour
{
    Animator animator;
    NavMeshAgent agent;

    void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        float motion = agent.velocity.magnitude;
        animator.SetFloat("motion", motion);
    }
}


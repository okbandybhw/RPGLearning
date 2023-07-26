using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHandler : MonoBehaviour
{
    [SerializeField]
    float attackRange = 1f;
    Animator animator;
    CharacterMovement characterMovement;
    InteractableObject target;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        characterMovement = GetComponent<CharacterMovement>();
    }

    public void Attack(InteractableObject target)
    {
        if (target == null)
            return;
        this.target = target;

        ProcessAttack();
    }

    void Update()
    {
        if (target != null)
            ProcessAttack();
    }

    void ProcessAttack()
    {
        var distance = Vector3.Distance(transform.position, target.transform.position);
        if (distance <= attackRange)
        {
            animator.SetTrigger("Attack");
            target = null;
        }
        else
        {
            characterMovement.SetDestination(target.transform.position);
        }
    }
}

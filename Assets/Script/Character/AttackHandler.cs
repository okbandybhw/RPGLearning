using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameData;

public class AttackHandler : MonoBehaviour
{
    [SerializeField]
    float attackRange = 1f;
    Animator animator;
    CharacterMovement characterMovement;
    InteractableObject target;
    Character character;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        characterMovement = GetComponent<CharacterMovement>();
        character = GetComponent<Character>();
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
        if (target == null)
            return;
        var targetCharacter = target.GetComponent<Character>();
        if (targetCharacter == null)
            return;

        var distance = Vector3.Distance(transform.position, target.transform.position);
        if (distance <= attackRange)
        {
            animator.SetTrigger("Attack");
            targetCharacter.TakeDamage(character.GetStatsValue(StatsType.Damage));

            target = null;
        }
        else
        {
            characterMovement.SetDestination(target.transform.position);
        }
    }
}

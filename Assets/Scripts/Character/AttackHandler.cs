using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameData;

public class AttackHandler : MonoBehaviour
{
    [SerializeField] float attackRange = 2.3f;
    [SerializeField] UIManager uiManager;
    Animator animator;
    CharacterMovement characterMovement;
    InteractableObject target;
    Character character;

    Coroutine AtkCoroutine;
    bool isAtk;

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
        if (this.target == target && isAtk)
            return;
        this.target = target;
        isAtk = true;
        AtkCoroutine = StartCoroutine(ProcessAttack());
    }

    void Update()
    {
        if (target != null && AtkCoroutine == null)
            AtkCoroutine = StartCoroutine(ProcessAttack());
    }

    IEnumerator ProcessAttack()
    {
        // Debug.Log("ProcessAttack");
        if (target == null)
            yield break;
        var targetCharacter = target.GetComponent<Character>();
        if (targetCharacter == null)
            yield break;

        var distance = Vector3.Distance(transform.position, target.transform.position);
        if (distance <= attackRange)
        {
            animator.SetTrigger("Attack");
            yield return new WaitUntil(() => { return !animator.GetBool("Attack"); });


            targetCharacter.TakeDamage(character.GetStatsValue(StatsType.Damage));
            uiManager.SetTargetCharacter(targetCharacter);
            target = null;
            targetCharacter = null;
        }
        else
        {
            characterMovement.SetDestination(target.transform.position);
        }

        isAtk = false;
        AtkCoroutine = null;
    }
}

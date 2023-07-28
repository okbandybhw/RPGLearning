using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameData;

public class Character : MonoBehaviour
{
    CharacterData characterData;
    //先放這邊之後移到characterData;
    [SerializeField]
    CharacterType characterType;
    Animator animator;

    void Awake()
    {
        characterData = new CharacterData();
        animator = GetComponent<Animator>();
    }

    public int GetStatsValue(StatsType statsType)
    {
        return characterData.GetStatsValue(statsType);
    }

    public void TakeDamage(int damage)
    {
        damage = ApplyDefence(damage);
        Debug.Log("take damage : " + damage);


        var life = GetStatsValue(StatsType.Life);
        life -= damage;
        if (life < 0)
            life = 0;

        characterData.UpdateLife(life);
        CheckDeath();
    }

    private int ApplyDefence(int damage)
    {
        damage -= GetStatsValue(StatsType.Armor);
        if (damage < 0)
            damage = 0;
        return damage;
    }

    private void CheckDeath()
    {
        if (characterData.GetStatsValue(StatsType.Life) <= 0)
        {
            Debug.Log("is death");
            animator.SetTrigger("DeathTrigger");
        }
    }
}

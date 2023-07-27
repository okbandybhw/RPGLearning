using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameData;

public class Character : MonoBehaviour
{
    CharacterData characterData;
    //����o�䤧�Ჾ��characterData;
    [SerializeField]
    CharacterType characterType;

    void Awake()
    {
        characterData = new CharacterData();
    }

    public int GetStatsValue(StatsType statsType)
    {
        return characterData.StatsS[(int)statsType].statsValue;
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("take damage");
    }
}

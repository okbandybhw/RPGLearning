using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameData
{
    public enum CharacterType
    {
        Player,
        Enemy
    }

    public enum StatsType
    {
        Life,
        Damage,
        Armor,
    }

    public class Stats
    {
        public StatsType statsType;
        public int statsValue;
        public int maxValue;

        public Stats(StatsType statsType, int statsValue = 0, int maxValue = 0)
        {
            this.statsType = statsType;
            this.statsValue = statsValue;
            this.maxValue = maxValue;
        }
    }

    public enum AttributeType
    {
        Strength,
        Dexterity,
        Intelligence,
    }

    public class Attribute
    {
        public AttributeType attributeType;
        public float attributeValue;

        public Attribute(AttributeType attributeType, float attributeValue = 0f)
        {
            this.attributeType = attributeType;
            this.attributeValue = attributeValue;
        }
    }

    public class CharacterData
    {
        private List<Attribute> attributeValues;
        private List<Stats> StatsS;
        //CharacterType characterType;

        public CharacterData()
        {
            Init();
        }

        public CharacterData(CharacterType characterType)
        {
            //this.characterType = characterType;
            Init();
        }

        private void Init()
        {
            attributeValues = new List<Attribute>();
            foreach (AttributeType attributeType in Enum.GetValues(typeof(AttributeType)))
                attributeValues.Add(new Attribute(attributeType, 0));

            StatsS = new List<Stats>();
            StatsS.Add(new Stats(StatsType.Life, 50, 50));
            StatsS.Add(new Stats(StatsType.Damage, 20));
            StatsS.Add(new Stats(StatsType.Armor, 10));
            // foreach (StatsType statsType in Enum.GetValues(typeof(StatsType)))
            //     StatsS.Add(new Stats(statsType));}
        }

        public int GetStatsValue(StatsType statsType)
        {
            return StatsS[(int)statsType].statsValue;
        }

        public int GetStatsMaxValue(StatsType statsType)
        {
            return StatsS[(int)statsType].maxValue;
        }

        private void UpdateStatsValue(StatsType statsType, int statsValue)
        {
            StatsS[(int)statsType].statsValue = statsValue;
        }

        public void UpdateLife(int life)
        {
            UpdateStatsValue(StatsType.Life, life);
        }
    }
}
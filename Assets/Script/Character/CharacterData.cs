using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CharacterData
{
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

        public Stats(StatsType statsType, int statsValue = 0)
        {
            this.statsType = statsType;
            this.statsValue = statsValue;
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
        public List<Attribute> attributeValues;
        public List<Stats> StatsS;

        public CharacterData()
        {
            attributeValues = new List<Attribute>();
            foreach (AttributeType attributeType in Enum.GetValues(typeof(AttributeType)))
                attributeValues.Add(new Attribute(attributeType, 0));

            StatsS = new List<Stats>();
            StatsS.Add(new Stats(StatsType.Life, 100));
            StatsS.Add(new Stats(StatsType.Damage, 20));
            StatsS.Add(new Stats(StatsType.Armor, 50));
            // foreach (StatsType statsType in Enum.GetValues(typeof(StatsType)))
            //     StatsS.Add(new Stats(statsType));
        }
    }
}
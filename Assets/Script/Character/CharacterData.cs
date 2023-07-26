using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CharacterData
{
    public enum AttributeType
    {
        Strength,
        Dexterity,
        Intelligence,
    }

    public class CharacterData
    {
        public List<Attribute> attributeValues;
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
}
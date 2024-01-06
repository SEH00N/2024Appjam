using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stat
{
	[SerializeField] float baseValue;
    public List<float> Modifiers = new List<float>();

    public float GetValue()
    {
        float finalValue = baseValue;
        for(int i = 0; i < Modifiers.Count; ++i)
            finalValue += Modifiers[i];

        return finalValue;
    }

    public void SetDefaultValue(float value)
    {
        baseValue = value;
    }

    public void AddModifier(float value)
    {
        if(value != 0)
            Modifiers.Add(value);
    }

    public void RemoveModifier(float value)
    {
        if(value != 0)
            Modifiers.Remove(value);
    }
}

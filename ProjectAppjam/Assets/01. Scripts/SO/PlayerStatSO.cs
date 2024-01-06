using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Player/Stat")]
public class PlayerStatSO : ScriptableObject
{
    public Stat MaxHP;
	public Stat Damage;
    public Stat Speed;

    protected Dictionary<StatType, FieldInfo> fieldInfoMap;

    private PlayerStat owner;

    public void SetOwner(PlayerStat owner) => this.owner = owner;
    public Stat GetStat(StatType type)
    {
        return fieldInfoMap[type]?.GetValue(this) as Stat;
    }
    public void IncreaseStat(StatType statType, float modifyValue, float duration = 0f)
        => owner.StartCoroutine(StatModifyCoroutine(statType, modifyValue, duration));

    public void Init()
    {
        if(fieldInfoMap == null)
            fieldInfoMap = new Dictionary<StatType, FieldInfo>();

        fieldInfoMap.Clear();
        Debug.Log(fieldInfoMap);

        Type stat = typeof(PlayerStatSO);
        foreach(StatType t in Enum.GetValues(typeof(StatType)))
        {
            FieldInfo statField = stat.GetField(t.ToString());
            Debug.Log(stat.ToString());
            fieldInfoMap.Add(t, statField);
        }
    }

    protected IEnumerator StatModifyCoroutine(StatType statType, float modifyValue, float duration)
    {
        Stat target = GetStat(statType);
        target.AddModifier(modifyValue);

        if(duration > 0f)
        {
            yield return new WaitForSeconds(duration);
            target.RemoveModifier(modifyValue);
        }
    }
}

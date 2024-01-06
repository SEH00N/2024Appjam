using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelUpCard : MonoBehaviour
{
	[SerializeField] List<StatData> cardStats;
    public UnityEvent<PlayerStat> OnSelectedEvent;

    public void Select(PlayerStat stat)
    {
        cardStats.ForEach(s => stat.Stat.IncreaseStat(s.type, s.value));
        OnSelectedEvent?.Invoke(stat);
    }
}

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelUpCard : MonoBehaviour
{
	[SerializeField] List<StatData> cardStats = new List<StatData>();
    public UnityEvent<PlayerStat> OnSelectedEvent;

    public int index;

    public void Select()
    {
        PlayerStat stat = IngameManager.Instance.PlayerStat;
        cardStats.ForEach(s => stat.Stat.IncreaseStat(s.type, s.value));
        OnSelectedEvent?.Invoke(stat);
    }
}

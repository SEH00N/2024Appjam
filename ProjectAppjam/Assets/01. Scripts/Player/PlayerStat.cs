using UnityEngine;
using UnityEngine.Events;

public class PlayerStat : MonoBehaviour
{
	[field : SerializeField]
    public PlayerStatSO Stat;

    [SerializeField] XPTableSO xpTable;
    public UnityEvent<int> OnLevelUpEvent;

    private int currentLevel = 1;
    private float xp;

    public void GetXP(float amount)
    {
        xp += amount;

        if(xp >= xpTable.table[currentLevel])
        {
            currentLevel++;
            OnLevelUpEvent?.Invoke(currentLevel);

            xp -= xpTable.table[currentLevel - 1];
        }
    }
}

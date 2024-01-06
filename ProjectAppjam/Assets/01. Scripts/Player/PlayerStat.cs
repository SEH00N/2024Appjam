using System;
using System.Collections;
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

    private void Awake()
    {
        Stat = ScriptableObject.Instantiate(Stat);
        Stat.Init();
        Stat.SetOwner(this);
    }

    public void GetXP(float amount)
    {
        xp += amount;

        if(xp >= xpTable.table[currentLevel])
        {
            currentLevel++;
            StartCoroutine(DelayCoroutine(0.5f, () => {
                OnLevelUpEvent?.Invoke(currentLevel);
            }));

            xp -= xpTable.table[currentLevel - 1];
        }
    }

    private IEnumerator DelayCoroutine(float delay, Action callback)
    {
        yield return new WaitForSeconds(delay);
        callback?.Invoke();
    }
}

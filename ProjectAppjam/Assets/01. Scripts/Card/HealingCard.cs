using UnityEngine;

public class HealingCard : MonoBehaviour
{
    public void Healing(float amount)
    {
        IngameManager.Instance.PlayerHealth.Heal(amount);
    }
}

using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    [SerializeField] float maxHP = 100;
    private float currentHP = 0f;

    public UnityEvent<GameObject, Vector3> OnDamagedEvent;
    public UnityEvent<GameObject> OnDeadEvent;

    public bool IsDead;

    private void Awake()
    {
        currentHP = maxHP;
    }

    public void OnDamaged(int damage = 0, GameObject performer = null, Vector3 point = default)
    {
        if(IsDead)
            return;

        currentHP -= damage;
        OnDamagedEvent?.Invoke(performer, point);

        if (currentHP <= 0f)
        {
            OnDeadEvent?.Invoke(performer);
            OnDie(performer);
            IsDead = true;
        }
    }

    public void Heal(float hp)
    {
        currentHP += hp;
    }

    private void OnDie(GameObject performer)
    {
    }
}

using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    private float currentHP = 0f;

    public UnityEvent<GameObject, Vector3> OnDamagedEvent;
    public UnityEvent<GameObject> OnDeadEvent;

    private PlayerStat stat;

    [SerializeField] HPUIPanel panel;

    public bool IsDead;

    private void Awake()
    {
        stat = GetComponent<PlayerStat>();
    }

    private void Start()
    {
        currentHP = stat.Stat.GetStat(StatType.MaxHP).GetValue();
        panel.SetHP(currentHP, currentHP);
    }

    public void OnDamaged(float damage = 0, GameObject performer = null, Vector3 point = default)
    {
        if(IsDead)
            return;

        currentHP -= damage;
        Debug.Log(currentHP);
        OnDamagedEvent?.Invoke(performer, point);

        if (currentHP <= 0f)
        {
            OnDeadEvent?.Invoke(performer);
            OnDie(performer);
            IsDead = true;
        }

        panel.SetHP(currentHP, stat.Stat.GetStat(StatType.MaxHP).GetValue());
    }

    public void Heal(float hp)
    {
        currentHP += hp;
    }

    private void OnDie(GameObject performer)
    {
        // PlayerAnimator player = transform.Find("Visual").GetComponent<PlayerAnimator>();
        // player.SetDead(true);

        // Destroy(GetComponent<Player>());
        // Destroy(GetComponent<Rigidbody>());
        // Destroy(GetComponent<Collider>());
    }
}

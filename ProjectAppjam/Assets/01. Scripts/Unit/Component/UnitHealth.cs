using UnityEngine;
using UnityEngine.Events;

public class UnitHealth : UnitComponent, IDamageable
{
    private float currentHP = 0f;

    public UnityEvent<GameObject, Vector3> OnDamagedEvent;
    public UnityEvent<GameObject> OnDeadEvent;

    public override void Init(UnitController controller)
    {
        base.Init(controller);
        currentHP = controller.UnitData.MaxHP;
    }

    public void OnDamaged(int damage = 0, GameObject performer = null, Vector3 point = default)
    {
        if(controller.IsDead)
            return;

        currentHP -= damage;
        OnDamagedEvent?.Invoke(performer, point);

        if (currentHP <= 0f)
        {
            OnDeadEvent?.Invoke(performer);
            OnDie(performer);
            controller.IsDead = true;
        }
    }

    private void OnDie(GameObject performer)
    {
        IngameManager.Instance.PlayerSkill.StoreProjectile(controller.UnitData.projectile);
        Destroy(gameObject, 1f);
    }
}

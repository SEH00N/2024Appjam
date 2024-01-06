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

    public void OnDamaged(float damage = 0, GameObject performer = null, Vector3 point = default)
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
        if(performer != null) // 플레이어가 직접 죽였을 때만 삼켜지기
            IngameManager.Instance.PlayerSkill.StoreProjectile(controller.UnitData.projectile);

        IngameManager.Instance.PlayerStat.GetXP(10);
        // Destroy(gameObject, 0.5f);
    }
}

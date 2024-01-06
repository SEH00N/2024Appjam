using UnityEngine;

public interface IDamageable
{
    public void OnDamaged(float damage = 0, GameObject performer = null, Vector3 point = default);
}
using UnityEngine;

public interface IDamageable
{
    public void OnDamaged(int damage = 0, GameObject performer = null, Vector3 point = default);
}
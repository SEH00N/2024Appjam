using UnityEngine;

public class SardineProjectile : Projectile
{
    protected override void OnCollision(Collision other)
    {
        if(1 << other.gameObject.layer != targetLayer)
            return;

        other.gameObject.GetComponent<IDamageable>()?.OnDamaged(10, other.gameObject, Vector3.zero);
        GetComponent<IDamageable>()?.OnDamaged(1000, null, Vector3.zero);
    }
}

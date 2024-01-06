using UnityEngine;

public class SardineProjectile : Projectile
{
    protected override void OnCollision(Collision other)
    {
        other.gameObject.GetComponent<IDamageable>().OnDamaged(10, other.gameObject, Vector3.zero);
        GetComponent<IDamageable>().OnDamaged(-10, other.gameObject, Vector3.zero);
    }
}

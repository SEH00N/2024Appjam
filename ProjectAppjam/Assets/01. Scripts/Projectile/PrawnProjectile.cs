using UnityEngine;

public class PrawnProjectile : Projectile
{
    protected override void OnCollision(Collision other)
    {
        Collider[] attack = Physics.OverlapSphere(new Vector3(transform.position.x, transform.position.y, transform.position.z), 3f, targetLayer);
        foreach (var attackObj in attack)
        {
            attackObj.GetComponent<IDamageable>()?.OnDamaged(1000, null, Vector3.zero);
        }
    }
}

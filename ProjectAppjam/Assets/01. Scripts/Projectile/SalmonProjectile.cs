using UnityEngine;

public class SalmonProjectile : Projectile
{
    protected override void OnCollision(Collision other)
    {
        Collider[] attack = Physics.OverlapSphere(new Vector3(transform.position.x, transform.position.y, transform.position.z), 3f, targetLayer);
        foreach (var attackObj in attack)
        {
            attackObj.GetComponent<UnitMovement>()?.SetMoveable(false);
            GetComponent<Rigidbody>()?.AddForce(transform.forward * -10);
            attackObj.GetComponent<IDamageable>()?.OnDamaged(1000, null, Vector3.zero);
            attackObj.GetComponent<UnitMovement>()?.SetMoveable(true);
        }
    }
}

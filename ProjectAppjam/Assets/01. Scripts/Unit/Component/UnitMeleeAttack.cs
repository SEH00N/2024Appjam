using UnityEngine;

public class UnitMeleeAttack : UnitAttack
{
    public int damage;

    public override void ActiveAttack()
    {
        Collider[] attackObj =  Physics.OverlapSphere(Vector3.zero, 1);
        foreach(var attack in attackObj)
        {
            if (attack.gameObject.tag != "Player") continue;

            attack.GetComponent<IDamageable>().OnDamaged(damage, attack.gameObject, Vector3.zero);
        }
    }
}

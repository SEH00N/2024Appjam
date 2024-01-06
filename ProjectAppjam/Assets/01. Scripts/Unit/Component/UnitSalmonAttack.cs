using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSalmonAttack : UnitAttack
{
    public override void ActiveAttack()
    {
        Collider[] attack = Physics.OverlapSphere(new Vector3(transform.position.x, transform.position.y, transform.position.z), 3f);
        foreach (var attackObj in attack)
        {
            attackObj.GetComponent<UnitMovement>().SetMoveable(false);
            GetComponent<Rigidbody>().AddForce(transform.forward * -10);
            attackObj.GetComponent<IDamageable>().OnDamaged(0, attackObj.gameObject, Vector3.zero);
            attackObj.GetComponent<UnitMovement>().SetMoveable(true);
        }
    }
}
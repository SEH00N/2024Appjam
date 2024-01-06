using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitJellyfishAttack : UnitAttack
{
    public override void ActiveAttack()
    {
        Collider[] attack = Physics.OverlapSphere(new Vector3(transform.position.x,transform.position.y,transform.position.z), 3f, targetLayer);
        foreach(var attackObj in attack)
        {
            attackObj.GetComponent<UnitMovement>().SetMoveable(false);
            attackObj.GetComponent<IDamageable>().OnDamaged(0, attackObj.gameObject, Vector3.zero);
        }
    }
}

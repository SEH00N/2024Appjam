using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitTurtleAttack : UnitAttack
{
    public override void ActiveAttack()
    {
        Collider[] attack = Physics.OverlapSphere(new Vector3(transform.position.x, transform.position.y, transform.position.z), 2f);
        foreach (var attackObj in attack)
        {
            if (attackObj.CompareTag("Player"))
            {
                attackObj.GetComponent<IDamageable>().OnDamaged(30, attackObj.gameObject, Vector3.zero);
            }
        }
    }
}

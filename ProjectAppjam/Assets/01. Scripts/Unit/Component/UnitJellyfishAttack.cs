using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitJellyfishAttack : MonoBehaviour
{
    void ActiveAttack()
    {
        Collider[] attack = Physics.OverlapSphere(Vector3.zero, 3f);
        foreach(var attackObj in attack)
        {
            
        }
    }
}

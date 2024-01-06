using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDamageable : MonoBehaviour, IDamageable
{
    public void OnDamaged(int damage = 0, GameObject performer = null, Vector3 point = default)
    {
        Debug.Log("АјАн : " + gameObject.name);
    }
}
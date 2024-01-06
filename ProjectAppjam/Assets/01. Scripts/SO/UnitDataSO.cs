using UnityEngine;

[CreateAssetMenu(menuName = "SO/UnitData")]
public class UnitDataSO : ScriptableObject
{
    public Projectile projectile;
    public string UnitName;

	public float MaxHP;
    public float MoveSpeed;
    public float RotateSpeed;
    public float AttackDamage;
    public float AttackDelay;
    public float AttackDistance;
    public float SightDistance;
    public float PatrolDelay;
}

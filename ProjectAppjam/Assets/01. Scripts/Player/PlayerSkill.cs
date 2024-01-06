using System.Collections.Generic;
using UnityEngine;

public class PlayerSkill : MonoBehaviour
{
    [SerializeField] Transform firePos;
    private Queue<Projectile> proejctiles = new Queue<Projectile>();

	private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse1))
        {
            if(proejctiles.Count <= 0)
                return;

            Projectile projectile = Instantiate(proejctiles.Dequeue(), firePos.position, Quaternion.identity);
            projectile.SetDirection(transform.forward);
        }
    }
}

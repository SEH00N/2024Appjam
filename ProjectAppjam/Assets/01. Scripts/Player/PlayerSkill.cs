using System.Collections.Generic;
using UnityEngine;

public class PlayerSkill : MonoBehaviour
{
    [SerializeField] Transform firePos;
    private Queue<Projectile> proejctiles = new Queue<Projectile>();

    public void StoreProjectile(Projectile p)
    {
        proejctiles.Enqueue(p);
    }

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

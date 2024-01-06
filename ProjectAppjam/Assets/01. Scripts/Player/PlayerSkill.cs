using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSkill : MonoBehaviour
{
    [SerializeField] Transform firePos;
    [SerializeField] Image fishImage;
    private Queue<Projectile> projectiles = new Queue<Projectile>();

    public void StoreProjectile(Projectile p)
    {
        projectiles.Enqueue(p);

        if(fishImage.color.a == 0f)
        {
            fishImage.sprite = p.Sprite;
            fishImage.color = Color.white;
        }
    }

	private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse1))
        {
            if(projectiles.Count <= 0)
                return;

            Projectile projectile = Instantiate(projectiles.Dequeue(), firePos.position, Quaternion.identity);
            projectile.SetDirection(CameraManager.Instance.MainCam.transform.forward);

            if(projectiles.Count > 0)
            {
                fishImage.sprite = projectiles.Peek().Sprite;
            }
            else
            {
                fishImage.color = new Color(0, 0, 0, 0);
            }
        }
    }
}

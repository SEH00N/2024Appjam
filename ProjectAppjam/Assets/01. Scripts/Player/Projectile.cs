using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float speed;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

	public void SetDirection(Vector3 direction)
    {
        rb.velocity = direction * speed;
    }
}

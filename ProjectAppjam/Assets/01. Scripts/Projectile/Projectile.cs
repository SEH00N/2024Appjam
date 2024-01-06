using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    [SerializeField] protected float speed;
    protected Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

	public void SetDirection(Vector3 direction)
    {
        rb.velocity = direction * speed;
    }

    protected virtual void OnCollisionEnter(Collision other)
    {
        OnCollision(other);
    }

    protected abstract void OnCollision(Collision other);
}

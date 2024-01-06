using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    [SerializeField] ParticleSystem particlePrefab;
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
        Instantiate(particlePrefab, transform.position, Quaternion.identity);
    }

    protected abstract void OnCollision(Collision other);
}

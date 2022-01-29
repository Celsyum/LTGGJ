using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float speed;
    private Vector2 direction;
    private LayerMask canCollideWith;

    private void Update()
    {
        
    }

    public void SpawnProjectile(Vector2 direction, float damage, LayerMask canCollideWith)
    {
        this.direction = direction;
        this.damage = damage;
        this.canCollideWith = canCollideWith;

        Debug.Log("Pew, bullet needs to be implemented");
        Destroy(gameObject);
    }
}
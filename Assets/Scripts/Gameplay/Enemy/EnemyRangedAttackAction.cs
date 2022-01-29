using UnityEngine;

public class EnemyRangedAttackAction : EnemyAttackAction
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform shootingPoint;
    [SerializeField] private LayerMask canCollideWith;

    protected override void Attack()
    {
        GameObject projectileInstance = Instantiate(projectilePrefab, shootingPoint.position, Quaternion.identity);

        Projectile projectile = projectileInstance.GetComponent<Projectile>();
        Vector2 projectileDirection = transform.parent.gameObject.GetComponent<EnemyController>().GetTargetDirection();
        projectile.SpawnProjectile(projectileDirection, AttackDamage, canCollideWith);
    }
}
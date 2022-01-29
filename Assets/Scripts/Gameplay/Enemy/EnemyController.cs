using UnityEngine;
using UnityEngine.AI;

public class EnemyController : StateMashine
{
    [Header("References")]
    [SerializeField] private EnemyAttackAction attackAction;

    [Header("Parameters")]
    [SerializeField] private float health;
    [SerializeField] private float speed;
    [SerializeField] private float attackDistance;
    [SerializeField] private float attackDamage;
    [SerializeField] private float attackSpeed;
    [SerializeField] private float minimalDistanceToTarget;
    [SerializeField] private float retreatRecalculationPeriod;
    [SerializeField] private LayerMask visionCollisionLayers;

    public float Health { get => health; set => health = value; }
    public float Speed { get => Agent.speed; set => Agent.speed = value; }
    public float AttackDistance { get => attackDistance; set => attackDistance = value; }
    public float AttackDamage { get => attackAction.AttackDamage; set => attackAction.AttackDamage = value; }
    public float AttackSpeed { get => attackAction.AttackSpeed; set => attackAction.AttackSpeed = value; }
    public float MinimalDistanceToTarget { get => minimalDistanceToTarget; set => minimalDistanceToTarget = value; }
    public EnemyAttackAction AttackAction { get => attackAction; }
    public float RetreatRecalculationPeriod { get => retreatRecalculationPeriod; set => retreatRecalculationPeriod = value; }
    public Transform Target { get; private set; }
    public NavMeshAgent Agent { get; private set; }

    private void Start()
    {
        Target = GameManager.Instance.Player.transform;
        Agent = GetComponent<NavMeshAgent>();
        Agent.updateRotation = false;
        Agent.updateUpAxis = false;

        Agent.speed = speed;
        AttackDamage = attackDamage;
        AttackSpeed = attackSpeed;

        SetState(new EnemyFollow(this));
    }

    public void Damage(float damage)
    {
        Health -= damage;

        if (Health <= 0)
        {
            Die();
        } 
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    public bool IsTargerVisible()
    {
        return IsTargerVisible(AttackDistance);
    }

    public bool IsTargerVisible(float distance)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, GetTargetDirection(), distance, visionCollisionLayers);

        return hit.transform == Target;
    }

    public float GetDistanceToTarget()
    {
        return Vector2.Distance(transform.position, Target.position);
    }

    public Vector2 GetTargetDirection()
    {
        return Target.position - transform.position;
    }

    public bool IsTargetTooClose()
    {
        return MinimalDistanceToTarget > GetDistanceToTarget();
    }
}
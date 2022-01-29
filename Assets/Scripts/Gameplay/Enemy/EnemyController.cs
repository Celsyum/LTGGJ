using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : StateMashine
{
    public float Health { get; set; }
    public float Speed { get => Agent.speed; set => Agent.speed = value; }
    public float AttackDistance { get; set; } = 1;
    public float AttackDamage { get; set; }

    public Transform Target { get; private set; }
    [SerializeField] private LayerMask visionCollisionLayers;

    public NavMeshAgent Agent { get; private set; }

    private void Start()
    {
        Target = GameManager.Instance.Player.transform;
        Agent = GetComponent<NavMeshAgent>();
        Agent.updateRotation = false;
        Agent.updateUpAxis = false;

        SetState(new EnemyFollow(this));
    }

    //protected override void Update()
    //{
    //    base.Update();

        
    //}

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
        Vector3 rayDirection = Target.position - transform.position;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, rayDirection, distance, visionCollisionLayers);

        return hit.transform == Target;
    }

    public float DistanceToTarget()
    {
        return Vector2.Distance(transform.position, Target.position);
    }
}
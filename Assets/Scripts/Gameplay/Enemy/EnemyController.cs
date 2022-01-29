using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : StateMashine
{
    [Header("Attributes")]
    [SerializeField] private float health;

    public Transform Target { get; private set; }
    [SerializeField] private LayerMask visionCollisionLayers;

    private void Start()
    {
        Target = GameManager.Instance.Player.transform;

        SetState(new EnemySpawn(this));
    }

    protected override void Update()
    {
        base.Update();
    }

    public void Damage(float damage)
    {
        health -= damage;

        if (health <= 0)
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
        float rayDistance = Vector2.Distance(transform.position, Target.position);

        return IsTargerVisible(rayDistance);
    }

    public bool IsTargerVisible(float distance)
    {
        Vector3 rayDirection = Target.position - transform.position;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, rayDirection, distance, visionCollisionLayers);

        return hit.transform == Target;
    }
}
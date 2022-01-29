using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : StateMashine
{
    [Header("Attributes")]
    [SerializeField] private float health;

    public Transform Target { get; private set; }

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
        RaycastHit2D hit;
        Vector3 rayDirection = Target.position - transform.position;
        hit = Physics2D.Raycast(transform.position, rayDirection);
        Debug.Log(hit.transform.name);
        return hit.transform == Target;
    }
}
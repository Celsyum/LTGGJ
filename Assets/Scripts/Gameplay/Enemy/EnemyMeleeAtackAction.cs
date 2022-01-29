using UnityEngine;

public class EnemyMeleeAtackAction : EnemyAttackAction
{
    protected override void Attack()
    {
        Debug.Log("bonk");
    }
}
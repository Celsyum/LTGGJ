using UnityEngine;

public class EnemyMeleeAtackAction : EnemyAttackAction
{
    [SerializeField] private CircleCollider2D attackArea;
    private PlayerController attackablePlayer;

    protected override void Attack()
    {
        if (attackablePlayer != null)
        {
            attackablePlayer.ReceiveDamage(AttackDamage);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player = collision.GetComponent<PlayerController>();
        if (player != null)
        {
            attackablePlayer = player;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        PlayerController player = collision.GetComponent<PlayerController>();
        if (player != null && player == attackablePlayer)
        {
            attackablePlayer = null;
        }
    }
}
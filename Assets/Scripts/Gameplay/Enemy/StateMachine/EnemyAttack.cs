﻿public class EnemyAttack : State
{
    public EnemyAttack(EnemyController controller) : base(controller)
    {
    }

    public override void Update()
    {
        if (!controller.IsTargerVisible())
        {
            controller.SetState(new EnemyFollow(controller));
        }
    }
}
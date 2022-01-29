using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : StateMashine
{
    void Start()
    {
        SetState(new EnemySpawn(this));
    }

    protected override void Update()
    {
        base.Update();
    }
}
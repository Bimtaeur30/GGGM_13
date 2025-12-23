using System.Collections;
using UnityEngine;

public class Hhedgehog : Enemy
{
    protected override void OnDeath()
    {
        base.enemyMovement.Speed += 1f;
    }
}

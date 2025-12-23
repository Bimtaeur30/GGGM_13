using System.Collections;
using UnityEngine;

public class Deer : Enemy
{
    protected override void OnDeath()
    {
        base.enemyMovement.Speed += 2.25f;
    }

    protected override IEnumerator Remove()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}

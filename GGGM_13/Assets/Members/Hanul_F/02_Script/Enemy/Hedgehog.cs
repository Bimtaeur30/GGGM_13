using System.Collections;
using NUnit.Framework;
using UnityEngine;

public class Hhedgehog : Enemy
{
    [SerializeField] private GameObject DamgeParticle;

    private readonly int isDead = Animator.StringToHash("IsDead");

    protected override void OnDamge()
    {
        GameObject particle = Instantiate(DamgeParticle,gameObject.transform.position, Quaternion.identity);
        particle.GetComponent<ParticleSystem>().Play();
    }

    protected override void OnDeath()
    {
        base.enemyMovement.Speed += 1f;
        DeadAniamtion();
    }

    private void DeadAniamtion()
    {
        base.animator.SetBool(isDead, true);
    }
}

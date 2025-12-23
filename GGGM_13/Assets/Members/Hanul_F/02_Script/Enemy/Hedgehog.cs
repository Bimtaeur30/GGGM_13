using System.Collections;
using UnityEngine;

public class Hhedgehog : Enemy
{
    [SerializeField] private GameObject DamgeParticle;
    protected override void OnDamge()
    {
        GameObject particle = Instantiate(DamgeParticle,gameObject.transform.position, Quaternion.identity);
        particle.GetComponent<ParticleSystem>().Play();
    }

    protected override void OnDeath()
    {
        base.enemyMovement.Speed += 1f;
    }
}

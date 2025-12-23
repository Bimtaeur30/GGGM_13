using System.Collections;
using UnityEngine;

public class Deer : Enemy
{
    [SerializeField] private GameObject DamgeParticle;
    protected override void OnDamge()
    {
        GameObject particle = Instantiate(DamgeParticle,gameObject.transform.position, Quaternion.identity);
        particle.GetComponent<ParticleSystem>().Play();
    }

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

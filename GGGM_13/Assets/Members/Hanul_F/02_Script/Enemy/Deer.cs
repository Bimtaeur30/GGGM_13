using System.Collections;
using DG.Tweening;
using UnityEngine;

public class Deer : Enemy
{
    [SerializeField] private GameObject DamgeParticle;

    private readonly int isDead = Animator.StringToHash("IsDead");

    private SpriteRenderer sr;
    [SerializeField] private float duration = 0.3f;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    protected override void OnDamge()
    {
        GameObject particle = Instantiate(DamgeParticle,gameObject.transform.position, Quaternion.identity);
        particle.GetComponent<ParticleSystem>().Play();
    }

    protected override void OnDeath()
    {
        base.enemyMovement.Speed += 1.6f;
    }

    protected override IEnumerator Remove()
    {
        yield return new WaitForSeconds(1f);
        Play();
    }

    public void Play()
    {
        sr.DOFade(0f, duration).OnComplete(() => Destroy(gameObject));
    }
}

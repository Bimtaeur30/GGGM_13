using System.Collections;
using DG.Tweening;
using NUnit.Framework;
using UnityEngine;

public class Hhedgehog : Enemy
{
    [SerializeField] private GameObject DamgeParticle;

    private readonly int isDead = Animator.StringToHash("IsDead");
    [SerializeField] private float duration = 0.3f;

    private SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public void Play()
    {
        sr.DOFade(0f, duration).OnComplete(() => Destroy(gameObject));
    }


    protected override void OnDamge()
    {
        GameObject particle = Instantiate(DamgeParticle,gameObject.transform.position, Quaternion.identity);
        particle.GetComponent<ParticleSystem>().Play();
    }

    protected override void OnDeath()
    {
        base.enemyMovement.Speed += 0.8f;
        DeadAniamtion();
    }

    

    protected override IEnumerator Remove()
    {
        yield return new WaitForSeconds(0.5f);
        Play();
    }

    private void DeadAniamtion()
    {
        base.animator.SetBool(isDead, true);
    }
}

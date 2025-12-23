using System.Collections;
using DG.Tweening;
using UnityEngine;

public class Deer : Enemy
{
    [SerializeField] private GameObject DamgeParticle;
    [SerializeField] private GameObject deathMessage;
    const float Xvalue = 0;
    const float Yvalue = 2.75f;

    private readonly int isDead = Animator.StringToHash("IsDead");
    [SerializeField] private float duration = 0.3f;

    private bool firstDeath = true;

    private SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }



    protected override void OnDamge()
    {
        GameObject particle = Instantiate(DamgeParticle, gameObject.transform.position, Quaternion.identity);
        particle.GetComponent<ParticleSystem>().Play();
    }

    protected override void OnDeath()
    {
        if (firstDeath)
        {
            base.enemyMovement.Speed += 0.8f;
            Instantiate(deathMessage,transform.position,Quaternion.identity);
            DeadAniamtion();
            firstDeath = false;
        }
    }

    protected override IEnumerator Remove()
    {
        yield return null;
    }

    public void Play()
    {
        sr.DOFade(0f, duration)
          .OnComplete(() =>
          {
              if (this != null && gameObject != null)
                  Destroy(gameObject);
          });
    }

    void Update()
    {
        if (!firstDeath)
        {
            if (transform.position.x <= Xvalue && transform.position.y <= Yvalue)
            {
                Play();
            }
        }
        else
            return;
    }


    private void DeadAniamtion()
    {
        base.animator.SetBool(isDead, true);
    }
}

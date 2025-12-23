using System;
using System.Collections;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    protected HealthSystem health;
    protected EnemyMovement enemyMovement;

    protected Animator animator;
    [SerializeField] private EventChannelSO onAnimalDied;

    protected virtual void Awake()
    {
        health = GetComponent<HealthSystem>();
        enemyMovement = GetComponent<EnemyMovement>();
        animator = GetComponent<Animator>();
        health._onDie += HandleDie;
        health._onDamage += HandleDamge;
    }

    private void HandleDamge()
    {
        OnDamge();
    }

    protected virtual void OnDisable()
    {
        health._onDie -= HandleDie;
    }

    protected abstract void OnDamge();

    private void HandleDie()
    {
        OnDeath();
        onAnimalDied.OnRaiseEvent();
        StartCoroutine(Remove());
    }
    protected abstract void OnDeath();

    protected virtual IEnumerator Remove()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
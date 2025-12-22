using System.Collections;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    protected HealthSystem health;
    protected EnemyMovement enemyMovement;

    protected virtual void Awake()
    {
        health = GetComponent<HealthSystem>();
        enemyMovement = GetComponent<EnemyMovement>();
        health._onDie += HandleDie;
    }

    protected virtual void OnDisable()
    {
        if (health != null) health._onDie -= HandleDie;
    }

    private void HandleDie()
    {
        OnDeath();
        StartCoroutine(Remove());
    }
    protected abstract void OnDeath();

    protected virtual IEnumerator Remove()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
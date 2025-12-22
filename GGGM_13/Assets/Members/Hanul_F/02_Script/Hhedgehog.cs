using UnityEngine;

public class Hhedgehog : MonoBehaviour
{
    private HealthSystem health = null;
    private EnemyMovement enemyMovement = null;
    void Awake()
    {
        health = GetComponent<HealthSystem>();
        enemyMovement = GetComponent<EnemyMovement>();
    }

    void Start()
    {
        health._onDie += Death;
    }

    private void Death()
    {
        
    }

    
}

using System.Collections;
using UnityEngine;

public class Hedgehog : MonoBehaviour
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
        //스프라이트 또는 애니메이션 변환
        enemyMovement.Speed += 2f;
        StartCoroutine(Remove());
    }

    private IEnumerator Remove()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }

    
}

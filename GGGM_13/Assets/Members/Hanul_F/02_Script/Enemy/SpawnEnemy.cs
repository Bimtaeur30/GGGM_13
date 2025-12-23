using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private GameObject center = null;
    [SerializeField] private Transform spawnPoint = null;
    [SerializeField] private List<GameObject> enemys = new List<GameObject>();
    private int currentStage = 0;

    private int MaxEenmy = 1;
    private int EnemyCount = 0;

    void Start()
    {
        StageManager.Instance._onNextStage += SettingStage;
        SettingStage(1);
    }

    public void SettingStage(int stage)
    {
        Debug.Log("스테이지 증가함");
        currentStage = stage;
        if(currentStage % 2 == 0)
        {
            MaxEenmy += 2;
        }
        EnemyCount = 0;
        StartCoroutine(EnemySpwan());
    }

    private IEnumerator EnemySpwan()
    {
        int oneCount;
        GameObject enemy;
        if (MaxEenmy - EnemyCount >= 5)
        {
            oneCount = 5;
        }
        else if (MaxEenmy - EnemyCount == 0)
        {
            oneCount = MaxEenmy;
        }
        else
        {
            oneCount = MaxEenmy - EnemyCount;
        }
        Debug.Log(EnemyCount);
        Debug.Log(MaxEenmy);
        Debug.Log(oneCount);


        for (int i =  0;  i < oneCount;i++ )
        {
            EnemyCount++;
            if (currentStage <= 4)
            {
                enemy =  Instantiate(enemys[0],spawnPoint.position,Quaternion.identity);
                enemy.GetComponent<EnemyMovement>().Setting(center);
                yield return new WaitForSeconds(2f);
            }
            else if (currentStage <= 8)
            {
                enemy = Instantiate(enemys[1],spawnPoint.position,Quaternion.identity);
                enemy.GetComponent<EnemyMovement>().Setting(center);
                yield return new WaitForSeconds(2f);
            }
            else
            {
                enemy =  Instantiate(enemys[UnityEngine.Random.Range(0,enemys.Count)]);
                enemy.GetComponent<EnemyMovement>().Setting(center);
                yield return new WaitForSeconds(2f);
            }
        }

        if (EnemyCount < MaxEenmy)
        {
            yield return new WaitForSeconds(1f);
            EnemySpwan();
        }
    }

    void OnDisable()
    {
        StageManager.Instance._onNextStage -= SettingStage;
    }


}

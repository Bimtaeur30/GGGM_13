using System.Collections.Generic;
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
    }

    public void SettingStage(int stage)
    {
        currentStage = stage;
        if(currentStage % 2 == 0)
        {
            MaxEenmy += 2;
        }
        EnemySpwan();
    }

    private void EnemySpwan()
    {
        
    }

    void OnDisable()
    {
        StageManager.Instance._onNextStage -= SettingStage;
    }


}

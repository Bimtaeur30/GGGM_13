using System.Collections.Generic;
using UnityEngine;

public class SpwanEnemy : MonoBehaviour
{
    [SerializeField] private GameObject center = null;
    [SerializeField] private Transform spwanPoint = null;
    [SerializeField] private List<GameObject> enemys = new List<GameObject>();
    private int currentStage = 0;

    void Start()
    {
        StageManager.Instance._onNextStage += SettingStage;
    }

    public void SettingStage(int stage)
    {
        currentStage = stage;
    }


}

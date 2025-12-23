using System;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    [SerializeField] private float basicTime;
    [SerializeField] private float multipleTime;
    public static StageManager Instance { get; private set; }
    public int CurrentStage { get; private set; }
    public int BestStage { get; private set; }
    private float currentNextTime;
    private float timer = 0;

    public event Action<int> _onNextStage;
    public event Action<int> _onChangeBestStage;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        CurrentStage = 1;
        BestStage = PlayerPrefs.GetInt("BestStage", 0);
        currentNextTime = basicTime;
        _onNextStage?.Invoke(CurrentStage);
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= currentNextTime)
        {
            NextStage();
        }
    }

    private void NextStage()
    {
        CurrentStage++;
        if (BestStage < CurrentStage)
        {
            BestStage = CurrentStage;
            PlayerPrefs.SetInt("BestStage", CurrentStage);
            _onChangeBestStage?.Invoke(BestStage);
        }
        currentNextTime += multipleTime;
        _onNextStage?.Invoke(CurrentStage);
        timer = 0;
    }
}

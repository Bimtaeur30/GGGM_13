using System;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    [SerializeField] private float basicTime;
    [SerializeField] private float multipleTime;
    public static StageManager Instance { get; private set; }
    private int currentStage = 1;
    private float currentNextTime;
    private float timer = 0;

    public event Action<int> _onNextStage;

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
        currentNextTime = basicTime;
        _onNextStage?.Invoke(currentStage);
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
        currentStage++;
        currentNextTime += multipleTime;
        _onNextStage?.Invoke(currentStage);
        timer = 0;
    }
}

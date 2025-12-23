using TMPro;
using UnityEngine;

public class StageUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _currentStageTxt;
    [SerializeField] private TextMeshProUGUI _bestStageTxt;

    private void Start()
    {
        StartSetBestStage();
        StageManager.Instance._onNextStage += ChangeCurrentStage;
        StageManager.Instance._onChangeBestStage += ChangeBestStage;
    }

    private void ChangeCurrentStage(int currentStage)
    {
        _currentStageTxt.text = $"{currentStage}";
    }

    private void ChangeBestStage(int currentStage)
    {
        _bestStageTxt.text = $"최고 스태이지: {currentStage}";
    }

    private void StartSetBestStage()
    {
        _bestStageTxt.text = $"최고 스태이지: {PlayerPrefs.GetInt("BestStage", 0)}";
    }
}

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
        StageManager.Instance._onNextStage += ChangeBestStage;
    }

    private void ChangeCurrentStage(int currentStage)
    {
        _currentStageTxt.text = $"현재 스태이지: {currentStage}";
    }

    private void ChangeBestStage(int currentStage)
    {
        if (currentStage > PlayerPrefs.GetInt("BestStage", 0))
        {
            PlayerPrefs.SetInt("BestStage", currentStage);
            _bestStageTxt.text = $"최고 스태이지: {currentStage}";
        }
    }

    private void StartSetBestStage()
    {
        _bestStageTxt.text = $"최고 스태이지: {PlayerPrefs.GetInt("BestStage", 0)}";
    }
}

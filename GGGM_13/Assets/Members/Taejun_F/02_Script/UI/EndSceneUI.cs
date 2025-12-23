using DG.Tweening;
using TMPro;
using UnityEngine;

public class EndSceneUI : MonoBehaviour
{
    [SerializeField] private CanvasGroup cg;
    [SerializeField] private TextMeshProUGUI scoreTxt;
    [SerializeField] private PlayerHP hp;

    private void OnEnable()
    {
        hp._onDie += RunEndUI;
    }

    private void OnDisable()
    {
        hp._onDie -= RunEndUI;
    }

    public void RunEndUI()
    {
        SoundManager.Instance.PlaySound(SFX.GameOver);
        cg.gameObject.SetActive(true);
        cg.DOFade(1f, 1f);
        scoreTxt.text = "최고기록: " + StageManager.Instance.BestStage + "\n현재기록: " + StageManager.Instance.CurrentStage;
    }

    public void OnRetryBtn()
    {
        SceneChangeManager.Instance.MoveScene(1);
    }

    public void OnHomeBtn() 
    {
        SceneChangeManager.Instance.MoveScene(0);
    }
}

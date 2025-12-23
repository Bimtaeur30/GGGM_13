using DG.Tweening;
using UnityEngine;

public class KeyShow : MonoBehaviour
{
    private CanvasGroup cg;

    private void Awake()
    {
        cg = gameObject.GetComponent<CanvasGroup>();
    }

    private void Start()
    {
        cg.alpha = 1.0f;
        Sequence seq = DOTween.Sequence();
        gameObject.SetActive(true);
        seq.AppendInterval(1.5f);
        seq.Append(cg.DOFade(0f, 1f).OnComplete(() => gameObject.SetActive(false)));
    }
}

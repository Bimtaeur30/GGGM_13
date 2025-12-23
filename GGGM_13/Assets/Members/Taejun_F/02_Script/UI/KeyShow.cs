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
        gameObject.SetActive(true);
        cg.DOFade(0f, 1f).OnComplete(() => gameObject.SetActive(false));
    }
}

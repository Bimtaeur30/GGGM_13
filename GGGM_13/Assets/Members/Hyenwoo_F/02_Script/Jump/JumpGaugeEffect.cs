using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class JumpGaugeEffect : MonoBehaviour
{
    private SpriteRenderer _render;

    private void Awake()
    {
        _render = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        gameObject.transform.DOScale(0.3f, 0f);
        _render.color = new Color(1, 1, 1, 1);
    }

    private void Start()
    {
        Show();
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
        Sequence effectSequnce = DOTween.Sequence();

        effectSequnce.Append(transform.DOScale(0.5f, 0.1f));
        effectSequnce.Append(_render.DOFade(0f, 0.1f));

        effectSequnce.AppendCallback(Hide);
    }
}

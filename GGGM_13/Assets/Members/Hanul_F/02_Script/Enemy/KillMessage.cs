using DG.Tweening;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class KillMessage : MonoBehaviour
{
    [SerializeField] private float yMove = 1f;
    [SerializeField] private float duration = 2f;

    private RectTransform rectTransform;
    private TextMeshPro textMesh;

    private void Awake()
    {
        textMesh = GetComponent<TextMeshPro>();
        rectTransform = GetComponent<RectTransform>();
    }

    private void Start()
    {
        FadeOut();
    }

    public void FadeOut()
    {

        float startY = rectTransform.localPosition.y;

        DOTween.Sequence()
            .Join(rectTransform.DOAnchorPosY(startY + yMove, duration).SetEase(Ease.OutQuad))
            .Join(textMesh.DOFade(0f, duration))
            .OnComplete(() => Destroy(gameObject));
    }
}

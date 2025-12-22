using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;
using System.Net;
using System;

public class CardAnimator : MonoBehaviour
{
    [Header("Hover")]
    [SerializeField] private CanvasGroup infoGroup;
    [SerializeField] private float fadeDuration = 0.2f;
    [SerializeField] private float rotateZ = 3f;

    [Header("Text PopUp")]
    [SerializeField] private float popupOffsetX = 30f;
    [SerializeField] private float popupDuration = 0.2f;

    private RectTransform[] _textRects;
    private Vector2[] _originTextPos;

    public void Init(RectTransform[] textRects)
    {
        _textRects = textRects;
        _originTextPos = new Vector2[textRects.Length];

        for (int i = 0; i < textRects.Length; i++)
            _originTextPos[i] = textRects[i].anchoredPosition;
    }

    public void PlayHover(Action _onComplete)
    {
        Sequence seq = DOTween.Sequence();

        seq.Join(infoGroup.DOFade(1f, fadeDuration));
        seq.Join(transform.DORotate(Vector3.forward * rotateZ, fadeDuration));

        seq.OnComplete(() =>
        {
            _onComplete.Invoke();
        });

        PlayTextPopUp();
    }

    public void StopHover()
    {
        Sequence seq = DOTween.Sequence();

        seq.Join(infoGroup.DOFade(0f, fadeDuration));
        seq.Join(transform.DORotate(Vector3.zero, fadeDuration));

        ResetTextPos();
    }

    private Sequence _textSequence;
    private void PlayTextPopUp()
    {
        _textSequence?.Kill();
        _textSequence = DOTween.Sequence();

        for (int i = 0; i < _textRects.Length; i++)
        {
            RectTransform rect = _textRects[i];
            rect.DOKill();

            rect.anchoredPosition = _originTextPos[i] + Vector2.left * popupOffsetX;

            _textSequence.Append(
                rect.DOAnchorPosX(_originTextPos[i].x, popupDuration)
            );
            _textSequence.AppendInterval(-0.05f); // »ìÂ¦ °ãÄ¡±â
        }
    }

    private void ResetTextPos()
    {
        for (int i = 0; i < _textRects.Length; i++)
        {
            _textRects[i].DOKill();
            _textRects[i].anchoredPosition = _originTextPos[i];
        }
    }
}

using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardInput : MonoBehaviour,
    IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] private GameObject onMouseImage;
    [SerializeField] private CardAnimator animator;
    [SerializeField] private RectTransform BaseSize;

    private bool _isPlaying = false;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (_isPlaying) return;

        _isPlaying = true;
        Action onPlayComplete = () => _isPlaying = false;

        onMouseImage.SetActive(true);
        animator.PlayHover(onPlayComplete);

        var layoutElement = BaseSize.GetComponent<LayoutElement>();

        DOTween.Kill(layoutElement); // 중복 Tween 방지

        layoutElement
            .DOPreferredSize(
                new Vector2(700f, layoutElement.preferredHeight),
                0.5f
            )
            .SetEase(Ease.OutBounce);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //_isPlaying = true;
        //Action onPlayComplete = () => _isPlaying = false;

        onMouseImage.SetActive(false);
        animator.StopHover();

        var layoutElement = BaseSize.GetComponent<LayoutElement>();

        DOTween.Kill(layoutElement); // 중복 Tween 방지

        layoutElement
            .DOPreferredSize(
                new Vector2(250f, layoutElement.preferredHeight),
                0.2f
            )
            .SetEase(Ease.OutQuad);

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("아이템 구매");
    }
}

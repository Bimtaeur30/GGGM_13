using DG.Tweening;
using System;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardInput : MonoBehaviour,
    IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] private GameObject onMouseImage;
    [SerializeField] private CardAnimator animator;
    [SerializeField] private RectTransform BaseSize;

    private LayoutElement le;

    private bool _isPlaying = false;

    public bool canSelect = true;

    private void Awake()
    {
        le = BaseSize.GetComponent<LayoutElement>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (canSelect == false) return;
        if (_isPlaying) return;

        _isPlaying = true;
        Action onPlayComplete = () => _isPlaying = false;

        onMouseImage.SetActive(true);
        animator.PlayHover(onPlayComplete);


        DOTween.Kill(le); // 중복 Tween 방지

        le
            .DOPreferredSize(
                new Vector2(700f, le.preferredHeight),
                0.5f
            )
            .SetEase(Ease.OutBounce).SetUpdate(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        HandleExit();
    }

    public void HandleExit()
    {
        if (canSelect == false) return;

        onMouseImage.SetActive(false);
        animator.StopHover();

        DOTween.Kill(le); // 중복 Tween 방지

        le.DOPreferredSize(new Vector2(250f, le.preferredHeight), 0.2f).SetEase(Ease.OutQuad).SetUpdate(true);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("아이템 구매");
    }
}

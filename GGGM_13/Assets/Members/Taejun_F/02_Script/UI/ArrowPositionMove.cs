using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class ArrowPositionMove : MonoBehaviour, IPointerEnterHandler
{
    [SerializeField] private RectTransform arrowObject;
    private RectTransform rec;
    private void Awake()
    {
        rec = GetComponent<RectTransform>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
            arrowObject.DOAnchorPosY(rec.anchoredPosition.y, 0.5f);
    }
}

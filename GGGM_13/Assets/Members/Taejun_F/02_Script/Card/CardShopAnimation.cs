using DG.Tweening;
using System.Linq;
using UnityEngine;

public class CardShopAnimation : MonoBehaviour
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private RectTransform cardParent;
    [SerializeField] private CanvasGroup cardPopParent;
    private float screenWidth;
    private float screenHeight;

    private void Awake()
    {
        RectTransform rectTransform = canvas.GetComponent<RectTransform>();
        screenHeight = rectTransform.rect.height;
        screenWidth = rectTransform.rect.width;
    }

    public void CardCloseDown()
    {
        float startY = -screenHeight / 2f - cardParent.rect.height / 2f;
        cardParent.DOAnchorPosY(startY, 1f)
          .SetEase(Ease.InBack).OnComplete(() =>
          {
              cardPopParent.DOFade(0f, 0.7f);
          });
    }
    public void CardPopsUp(GameObject[] cards)
    {
        Debug.Log(screenHeight);
        Debug.Log(cardParent.rect.height);
        float startY = -screenHeight / 2f - cardParent.rect.height / 2f;

        cardParent.anchoredPosition = new Vector2(
            cardParent.anchoredPosition.x,
            startY
        );

        foreach (GameObject card in cards)
        {
            if (card.TryGetComponent<CardView>(out CardView data))
            {
                data.animator.SetTrigger("OnAppear");
            }
        }

        cardParent.DOAnchorPosY(0f, 1f).SetEase(Ease.OutBounce);

        cardPopParent.DOFade(1f, 0.7f);
    }

}

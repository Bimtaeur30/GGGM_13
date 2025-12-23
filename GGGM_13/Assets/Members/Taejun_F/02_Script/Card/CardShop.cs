using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CardShop : MonoBehaviour
{
    [SerializeField] private Transform cardSpawnPos;
    [SerializeField] private GameObject cardPref;
    [SerializeField] private CardData[] sellCards;

    [Header("ShopAnim")]
    [SerializeField] private CardShopAnimation cardShopAnim;

    private List<GameObject> spawnedCards = new List<GameObject>();

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RollShop();
        }
    }

    private void PurchaseItem(CardData data, CardView view)
    {
        CardData card = sellCards.FirstOrDefault(c => c == data);

        view.animator.SetTrigger("OnClicked");
        spawnedCards.ForEach((x) =>
        {
            CardInput ci = x.GetComponent<CardInput>();
            ci.HandleExit();
            ci.canSelect = false;
        });

        cardShopAnim.CardCloseDown();
    }

    public void RollShop()
    {
        if (spawnedCards .Count > 0)
        {
            spawnedCards.ForEach((x) =>
            {
                Destroy(x);
            });
            spawnedCards.Clear();
        }

        for (int i = 0; i < 3; i++)
        {
            int randIdx = Random.Range(0, sellCards.Length);

            CardData card = sellCards[randIdx];
            CardView cardView = Instantiate(cardPref, cardSpawnPos).GetComponent<CardView>();
            cardView.SetUI(sellCards[randIdx]);
            cardView.SetAnimator(card.ItemAnimator);
            cardView.button.onClick.AddListener(() =>
            {
                PurchaseItem(card, cardView);
            });

            spawnedCards.Add(cardView.gameObject);
        }

        cardShopAnim.CardPopsUp(spawnedCards.ToArray());
    }
}

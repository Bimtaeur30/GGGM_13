using NUnit.Framework;
using UnityEngine;

public class CardShop : MonoBehaviour
{
    [SerializeField] private Transform cardSpawnPos;
    [SerializeField] private GameObject cardPref;
    [SerializeField] private CardData[] sellCards;

    private void Start()
    {
        RollShop();
    }

    public void RollShop()
    {
        for (int i = 0; i < sellCards.Length; i++)
        {
            CardData card = sellCards[i];
            CardView cardView = Instantiate(cardPref, cardSpawnPos).GetComponent<CardView>();
            cardView.SetUI(sellCards[Random.Range(0, sellCards.Length)]);
        }
    }
}

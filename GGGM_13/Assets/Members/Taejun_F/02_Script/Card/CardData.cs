using UnityEngine;

[System.Serializable]
public class CardData
{
    [Header("Ability")]
    public ICardAbillity Abillity;

    [Header("Setting")]
    public string ItemName;
    public int ItemPrice;
    [TextArea]
    public string[] ItemDescriptions;

    public CardData(string itemName, int itemPrice, string[] itemDesc)
    {
        ItemName = itemName;
        ItemPrice = itemPrice;
        ItemDescriptions = itemDesc;
    }
}

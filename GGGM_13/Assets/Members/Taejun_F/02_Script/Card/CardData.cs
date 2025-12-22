using UnityEngine;

public enum CardEnum
{
    스킬, 보호구
}

[System.Serializable]
public class CardData
{
    [Header("Ability")]
    public ICardAbillity Abillity;

    [Header("Setting")]
    public string ItemName;
    public CardEnum CardEnum;
    [TextArea]
    public string[] ItemDescriptions;

    [Header("Animation")]
    public Animator animator;

    public CardData(string itemName, CardEnum itemEnum, string[] itemDesc)
    {
        ItemName = itemName;
        ItemDescriptions = itemDesc;
    }
}

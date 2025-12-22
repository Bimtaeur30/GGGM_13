using UnityEngine;

public enum CardEnum
{
    스킬, 보호구
}

[System.Serializable]
public class CardData
{
    [Header("Ability")]
    public CardAbilitySO AbilitySO;

    [Header("Setting")]
    public string ItemName;
    public CardEnum CardEnum;
    [TextArea]
    public string[] ItemDescriptions;

    public bool IsUsed = false;
}

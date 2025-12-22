using TMPro;
using UnityEngine;
using System.Text;

public class CardView : MonoBehaviour
{
    [Header("Text")]
    [SerializeField] private TextMeshProUGUI itemNameTxt;
    [SerializeField] private TextMeshProUGUI itemPriceTxt;
    [SerializeField] private TextMeshProUGUI itemDescTxt;
    [SerializeField] private CardAnimator animator;

    private void Start()
    {
        RectTransform[] aaa = new RectTransform[3] {itemPriceTxt.rectTransform, itemNameTxt.rectTransform, itemDescTxt.rectTransform };
        animator.Init(aaa);
    }

    public void SetUI(CardData data)
    {
        itemNameTxt.text = data.ItemName;
        itemPriceTxt.text = $"{data.ItemPrice} ÄÚÀÎ";

        var sb = new StringBuilder();
        foreach (var desc in data.ItemDescriptions)
            sb.AppendLine($"- {desc}");

        itemDescTxt.text = sb.ToString();
    }

    public RectTransform[] GetTextRects()
    {
        return new[]
        {
            itemNameTxt.rectTransform,
            itemPriceTxt.rectTransform,
            itemDescTxt.rectTransform
        };
    }
}

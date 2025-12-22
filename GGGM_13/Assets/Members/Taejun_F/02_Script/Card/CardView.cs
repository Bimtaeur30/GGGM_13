using TMPro;
using UnityEngine;
using System.Text;
using UnityEngine.UI;

public class CardView : MonoBehaviour
{
    [Header("Text")]
    [SerializeField] private TextMeshProUGUI itemNameTxt;
    [SerializeField] private TextMeshProUGUI itemPriceTxt;
    [SerializeField] private TextMeshProUGUI itemDescTxt;
    [SerializeField] private CardAnimator cardAnimatorCs;

    [field:SerializeField] public Animator animator { get; private set; }
    [field: SerializeField] public Button button { get; private set; }


    private void Start()
    {
        RectTransform[] aaa = new RectTransform[3] {itemPriceTxt.rectTransform, itemNameTxt.rectTransform, itemDescTxt.rectTransform };
        cardAnimatorCs.Init(aaa);
    }

    public void SetUI(CardData data)
    {
        itemNameTxt.text = data.ItemName;
        itemPriceTxt.text = "ºÐ·ù:" + $"{data.CardEnum}";

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

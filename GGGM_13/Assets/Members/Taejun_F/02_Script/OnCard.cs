using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnCard : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [Header("TextSetting")]
    [SerializeField] private TextMeshProUGUI ItemNameTxt;
    [SerializeField] private TextMeshProUGUI ItemPriceTxt;
    [SerializeField] private TextMeshProUGUI ItemDescTxt;

    [Header("OnMouseUI")]
    [SerializeField] private GameObject OnMouseImage;
    [SerializeField] private CanvasGroup ItemInfoGroup;

    private void Start()
    {
        string[] aa = new string[2] {"더 좋아진 선능!", "50%확률로 공격무시함!"};
        SetCardUI("삼뚝", 1345, aa);
    }

    public void SetCardUI(string ItemName, int ItemPrice, string[] ItemDesc)
    {
        ItemNameTxt.text = ItemName;
        ItemPriceTxt.text = ItemPrice.ToString() + "코인";
        ItemDescTxt.text = ""; // 카드 텍스트 초기화 한번 해주고
        for (int i = 0; i < ItemDesc.Length; i++)
        {
            string desc = ItemDesc[i];
            ItemDescTxt.text += "- " + desc + "\n"; // 설명 쓴다음 줄넘김
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("해당 아이템 구매했습니다.");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        OnMouseImage.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        OnMouseImage.SetActive(false);
    }
}

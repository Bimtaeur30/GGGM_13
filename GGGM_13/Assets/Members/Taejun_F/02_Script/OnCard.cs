using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnCard : MonoBehaviour, IPointerUpHandler, IPointerDownHandler, IPointerClickHandler
{
    [Header("TextSetting")]
    [SerializeField] private TextMeshProUGUI ItemNameTxt;
    [SerializeField] private TextMeshProUGUI ItemPriceTxt;
    [SerializeField] private TextMeshProUGUI ItemDescTxt;

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

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("마우스 내림");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("마우스 올림");
    }
}

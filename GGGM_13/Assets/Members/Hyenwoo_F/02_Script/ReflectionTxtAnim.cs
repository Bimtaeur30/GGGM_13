using DG.Tweening;
using TMPro;
using UnityEngine;

public class ReflectionTxtAnim : MonoBehaviour
{
    private TextMeshPro text;

    private void Awake()
    {
        text = GetComponent<TextMeshPro>();
    }

    private void OnEnable()
    {
        gameObject.transform.position = Vector3.zero;
        text.color = new Color(1, 1, 1, 1);
    }

    public void Show(int persent)
    {
        Sequence sequence = DOTween.Sequence();
        text.text = $"นÝป็! ({persent}%)";
        gameObject.SetActive(true);

        sequence.Insert(0.2f, gameObject.transform.DOMoveY(2, 0.5f));
        sequence.Insert(0.3f, text.DOFade(0f, 0.5f));
        sequence.AppendCallback(Hide);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}

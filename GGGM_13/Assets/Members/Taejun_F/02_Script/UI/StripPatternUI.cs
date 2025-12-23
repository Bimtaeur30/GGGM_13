using DG.Tweening;
using System;
using System.Collections;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StripPatternUI : MonoBehaviour
{
    [SerializeField] private RectTransform[] sticks;
    float xStickPos;

    public void SetStickSize(float _screenXSize, float _screenYSize)
    {

        xStickPos = _screenXSize + sticks[0].sizeDelta.x / 2;

        for (int i = 0; i < sticks.Length; i++)
        {
            RectTransform t = sticks[i];
            t.sizeDelta = new Vector2(t.sizeDelta.x, _screenYSize / sticks.Length);
            t.anchoredPosition = new Vector2(xStickPos, -(_screenYSize / sticks.Length * i));
        }
    }

    public void OpenEffect()
    {
        Sequence seq = DOTween.Sequence();
        seq.Pause();

        float deley = 0f;

        foreach (var t in sticks)
        {
            Debug.Log(xStickPos);
            seq.Join(t.DOAnchorPosX(xStickPos, 1f).SetDelay(deley).SetEase(Ease.Linear));
            deley += 0.07f;
            //yield return new WaitForSeconds(0.2f);
        }

        seq.Play();
    }

    public IEnumerator CorCloseEffect(Action _onComplete)
    {
        Sequence seq = DOTween.Sequence();
        seq.Pause();

        float deley = 0f;

        foreach (var t in sticks)
        {
            seq.Join(t.DOAnchorPosX(0, 1f).SetDelay(deley).SetEase(Ease.Linear));
            deley += 0.07f;
            //yield return new WaitForSeconds(0.2f);
        }

        seq.Play();

        yield return new WaitForSeconds(0.5f);
        seq.OnComplete(() =>
        {
            _onComplete?.Invoke();
        });
    }
}

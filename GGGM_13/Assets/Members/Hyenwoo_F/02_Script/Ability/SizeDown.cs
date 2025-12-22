using System;
using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "SizeDown", menuName = "Scriptable Objects/SizeDown")]
public class SizeDown : CardAbilitySO
{
    [SerializeField] private float downSize;
    [SerializeField] private float applicationTime;
    public event Action<float, float> _onSizeDown;

    public override void Excute()
    {
        _onSizeDown?.Invoke(downSize, applicationTime);
        YHWGameManager.Instance.sizeDownParticle.Play();
    }
}

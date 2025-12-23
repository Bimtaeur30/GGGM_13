using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Invincibility", menuName = "Scriptable Objects/Invincibility")]
public class Invincibility : CardAbilitySO
{
    [SerializeField] private float _applicationTime;
    public event Action<float> _onInvincibility;

    public override void Excute()
    {
        _onInvincibility?.Invoke(_applicationTime);
    }
}

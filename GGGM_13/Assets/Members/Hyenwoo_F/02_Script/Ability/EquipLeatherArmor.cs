using System;
using UnityEngine;

[CreateAssetMenu(fileName = "EquipLeatherArmor", menuName = "Scriptable Objects/EquipLeatherArmor")]
public class EquipLeatherArmor : CardAbilitySO
{
    public event Action _onLeatherArmor;

    public override void Excute()
    {
        _onLeatherArmor?.Invoke();
    }
}
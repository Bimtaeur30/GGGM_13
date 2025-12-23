using System;
using UnityEngine;

[CreateAssetMenu(fileName = "EquipIronArmor", menuName = "Scriptable Objects/EquipIIronArmor")]
public class EquipIronArmor : CardAbilitySO
{
    public event Action _onIronArmor;

    public override void Excute()
    {
        _onIronArmor?.Invoke();
    }
}

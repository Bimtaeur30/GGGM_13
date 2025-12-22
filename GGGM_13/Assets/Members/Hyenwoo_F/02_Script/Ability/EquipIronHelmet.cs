using System;
using UnityEngine;

[CreateAssetMenu(fileName = "EquipIronHelmet", menuName = "Scriptable Objects/EquipIronHelmet")]
public class EquipIronHelmet : CardAbilitySO
{
    public event Action _onEquipIronHelmet;

    public override void Excute()
    {
        _onEquipIronHelmet?.Invoke();
    }
}

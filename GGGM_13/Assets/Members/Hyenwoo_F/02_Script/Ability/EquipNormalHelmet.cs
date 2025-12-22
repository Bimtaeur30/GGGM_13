using System;
using UnityEngine;

[CreateAssetMenu(fileName = "EquipNormalHelmet", menuName = "Scriptable Objects/EquipNormalHelmet")]
public class EquipNormalHelmet : CardAbilitySO
{
    public event Action _onEquipHelmet;

    public override void Excute()
    {
        _onEquipHelmet?.Invoke();
    }

}

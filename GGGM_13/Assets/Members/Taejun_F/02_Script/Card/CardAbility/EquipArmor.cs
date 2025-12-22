using UnityEngine;

[CreateAssetMenu(fileName = "EquipArmor", menuName = "Scriptable Objects/EquipArmor")]
public class EquipArmor : CardAbilitySO
{
    public override void Excute()
    {
        Debug.Log("방어구 착용");
    }
}

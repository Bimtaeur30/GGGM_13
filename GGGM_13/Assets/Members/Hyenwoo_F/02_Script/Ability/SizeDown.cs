using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "SizeDown", menuName = "Scriptable Objects/SizeDown")]
public class SizeDown : CardAbilitySO
{
    [SerializeField] private float downSize;
    [SerializeField] private float applicationTime;

    public override void Excute()
    {
        YHWGameManager.Instance.Player.GetComponent<YHWPlayer>().PlayerSizeDown(downSize, applicationTime);
    }
}

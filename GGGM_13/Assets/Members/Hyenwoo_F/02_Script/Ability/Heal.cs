using UnityEngine;

[CreateAssetMenu(fileName = "Heal", menuName = "Scriptable Objects/Heal")]
public class Heal : CardAbilitySO
{
    [SerializeField] private int healValue;
    public override void Excute()
    {
        YHWGameManager.Instance.Player.GetComponent<PlayerHP>().GetHeal(healValue);
        YHWGameManager.Instance.healParticle.Play();
    }
}

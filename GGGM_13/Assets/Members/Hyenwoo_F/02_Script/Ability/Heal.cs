using UnityEngine;

[CreateAssetMenu(fileName = "Heal", menuName = "Scriptable Objects/Heal")]
public class Heal : CardAbilitySO
{
    [SerializeField] private int healValue;
    public override void Excute()
    {
        for (int i = 0; i < healValue; i++)
        {
            YHWGameManager.Instance.Player.GetComponent<PlayerHP>().GetHeal();
        }
        YHWGameManager.Instance.healParticle.Play();
    }
}

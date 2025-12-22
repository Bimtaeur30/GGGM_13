using UnityEngine;

public interface IDamageable
{
    public void GetDamage(int value, GameObject dealer);
    public void GetHeal(int value, GameObject healer);
}

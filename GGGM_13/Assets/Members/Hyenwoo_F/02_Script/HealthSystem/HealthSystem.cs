using System;
using UnityEngine;

public class HealthSystem : MonoBehaviour, IDamageable
{
    [field:SerializeField] public int MaxHp { get; private set; }
    [field:SerializeField] public int Hp { get; private set; }

    public event Action _onDamage;
    public event Action _onDie;

    private void Start()
    {
        Hp = MaxHp;
    }

    public void GetDamage(int value, GameObject dealer)
    {
        Hp -= value;
        _onDamage?.Invoke();
        if (Hp <= 0)
        {
            // gameObject.SetActive(false);
            _onDie?.Invoke();
        }
    }

    public void GetHeal(int value, GameObject healer)
    {
        Hp += value;
        Hp = Mathf.Clamp(Hp, 0, MaxHp);
    }
}

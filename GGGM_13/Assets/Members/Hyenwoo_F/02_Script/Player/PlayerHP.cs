using System;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    [field:SerializeField] public int MaxHp { get; private set; }
    [field:SerializeField] public int Hp { get; private set; }

    public event Action _onDamage;
    public event Action _onDie;
    public event Action<int> _onHeal;

    private void Start()
    {
        Hp = MaxHp;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 7)
        {
            collision.gameObject.SetActive(false);
            GetDamage(1);
        }
    }

    public void GetDamage(int value)
    {
        Hp -= value;
        _onDamage?.Invoke();
        if (Hp <= 0)
        {
            gameObject.SetActive(false);
            _onDie?.Invoke();
        }
    }

    public void GetHeal(int value)
    {
        Hp += value;
        Hp = Mathf.Clamp(Hp, 0, MaxHp);
        _onHeal?.Invoke(value);
    }
}

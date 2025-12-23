using System;
using Unity.Cinemachine;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    [field:SerializeField] public int MaxHp { get; private set; }
    [field:SerializeField] public int Hp { get; private set; }
    private CinemachineImpulseSource impulseSource;

    public event Action _onDamage;
    public event Action _onDie;
    public event Action _onHeal;

    private void Awake()
    {
        impulseSource = GetComponent<CinemachineImpulseSource>();
    }

    private void Start()
    {
        Hp = MaxHp;
    }

    // private void OnCollisionEnter2D(Collision2D collision)
    // {
    //     if (collision.gameObject.layer == 7)
    //     {
    //         collision.gameObject.SetActive(false);
    //         GetDamage(1);
    //     }
    // }

    public void GetDamage(int value)
    {
        Hp -= value;
        impulseSource.GenerateImpulse();
        if (Hp <= 0)
        {
            _onDie?.Invoke();
        }
        _onDamage?.Invoke();
    }

    public void GetHeal()
    {
        Hp += 1;
        Hp = Mathf.Clamp(Hp, 0, MaxHp);
        _onHeal?.Invoke();
    }
}

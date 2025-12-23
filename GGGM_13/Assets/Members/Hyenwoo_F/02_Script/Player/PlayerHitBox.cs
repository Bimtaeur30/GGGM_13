using System;
using UnityEngine;

public class PlayerHitBox : MonoBehaviour
{
    private YHWPlayer player;
    public bool LeatherSet { get; private set; }
    public bool IronSet { get; private set; }
    private int count = 0;

    public event Action _onChangeCos;

    private void Awake()
    {
        player = GetComponentInParent<YHWPlayer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 7)
        {
            collision.gameObject.SetActive(false);
            if (LeatherSet)
            {
                if (UnityEngine.Random.Range(0,4) == 0)
                {
                    count++;
                    CalculateCount();
                }
                else
                    player.HPCompo.GetDamage(1);
            }
            else if (IronSet)
            {
                if (UnityEngine.Random.Range(0,2) == 0)
                {
                    count++;
                    CalculateCount();
                }
                else
                    player.HPCompo.GetDamage(1);
            }
            else
                player.HPCompo.GetDamage(1);
        }
    }

    private void CalculateCount()
    {
        if (LeatherSet)
        {
            if (count >= 2)
            {
                LeatherSet = false;
                count = 0;
                YHWGameManager.Instance.helmetBrokenParticle.Play();
            }
        }
        else if (IronSet)
        {
            if (count >= 5)
            {
                IronSet = false;
                count = 0;
                YHWGameManager.Instance.helmetBrokenParticle.Play();
            }
        }
    }

    public void SetLeather()
    {
        LeatherSet = true;
        if (IronSet)
        {
            IronSet = false;
            count = 0;
        }
        _onChangeCos?.Invoke();
    }

    public void SetIron()
    {
        IronSet = true;
        if (LeatherSet)
        {
            LeatherSet = false;
            count = 0;
        }
        _onChangeCos?.Invoke();
    }
}

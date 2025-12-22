using UnityEngine;

public class PlayerHitBox : MonoBehaviour
{
    private YHWPlayer player;
    private bool leatherSet;
    private bool ironset;
    private int count = 0;

    private void Awake()
    {
        player = GetComponentInParent<YHWPlayer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 7)
        {
            collision.gameObject.SetActive(false);
            if (leatherSet)
            {
                if (Random.Range(0,4) == 0)
                {
                    count++;
                    CalculateCount();
                }
                else
                    player.HPCompo.GetDamage(1);
            }
            else if (ironset)
            {
                if (Random.Range(0,2) == 0)
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
        if (leatherSet)
        {
            if (count >= 2)
            {
                leatherSet = false;
                count = 0;
            }
        }
        else if (ironset)
        {
            if (count >= 5)
            {
                ironset = false;
                count = 0;
            }
        }
    }

    public void SetLeather()
    {
        leatherSet = true;
        if (ironset)
        {
            ironset = false;
            count = 0;
        }
    }

    public void SetIron()
    {
        ironset = true;
        if (leatherSet)
        {
            leatherSet = false;
            count = 0;
        }
    }
}

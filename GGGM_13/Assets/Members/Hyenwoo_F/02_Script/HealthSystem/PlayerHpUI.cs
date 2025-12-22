using System.Collections.Generic;
using UnityEngine;

public class PlayerHpUI : MonoBehaviour
{
    [SerializeField] private GameObject heartUI;
    private List<GameObject> heartPool;
    private PlayerHP playerHp;

    private void Start()
    {
        playerHp = YHWGameManager.Instance.Player.GetComponent<PlayerHP>();
        HeartPool();
        playerHp._onDamage += DeleteHeart;
        playerHp._onHeal += HealHeart;
    }

    private void HeartPool()
    {
        heartPool = new List<GameObject>();
        for (int i = 0; i < playerHp.MaxHp; i++)
        {
            heartPool.Add(Instantiate(heartUI, gameObject.transform));
        }
    }

    private void DeleteHeart()
    {
        foreach(var item in heartPool)
        {
            if (item.activeSelf)
            {
                item.SetActive(false);
                break;
            }
        }
    }

    private void HealHeart()
    {
        foreach(var item in heartPool)
        {
            if (!item.activeSelf)
            {
                item.SetActive(true);
                break;
            }
        }
    }
}

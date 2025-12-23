using System.Collections.Generic;
using UnityEngine;

public class PlayerHpUI : MonoBehaviour
{
    [SerializeField] private GameObject heartUI;
    [SerializeField] private GameObject blankHeartUI;
    private List<GameObject> heartPool;
    private List<GameObject> blankHeartPool;
    private PlayerHP playerHp;

    private void Start()
    {
        playerHp = YHWGameManager.Instance.Player.GetComponent<PlayerHP>();
        HeartPool();
        BlankHeartPool();
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

        SetBlankHeart();
    }

    private void HealHeart()
    {
        for (int i = 0; i < heartPool.Count; i++)
        {
            if (!heartPool[i].activeSelf)
            {
                heartPool[i].SetActive(true);
                break;
            }
        }

        DeleteBlankHeart();
    }

    private void BlankHeartPool()
    {
        blankHeartPool = new List<GameObject>();
        for (int i = 0; i < playerHp.MaxHp; i++)
        {
            blankHeartPool.Add(Instantiate(blankHeartUI, gameObject.transform));
            blankHeartPool[i].SetActive(false);
        }
    }

    private void SetBlankHeart()
    {
        for (int i = 0; i < blankHeartPool.Count; i++)
        {
            if (!blankHeartPool[i].activeSelf)
            {
                blankHeartPool[i].SetActive(true);
                break;
            }
        }
    }

    private void DeleteBlankHeart()
    {
        for (int i = 0; i < blankHeartPool.Count; i++)
        {
            if (blankHeartPool[i].activeSelf)
            {
                blankHeartPool[i].SetActive(false);
                break;
            }
        }
    }
}

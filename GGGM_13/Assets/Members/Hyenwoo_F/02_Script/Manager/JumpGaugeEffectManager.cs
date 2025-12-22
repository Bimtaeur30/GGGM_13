
using System.Collections.Generic;
using UnityEngine;

public class JumpGaugeEffectManager : MonoBehaviour
{
    [SerializeField] private GameObject jumpGaugeEffectPre;
    public static JumpGaugeEffectManager Instance { get; private set; }
    private List<GameObject> jumpGaugeEffectPool;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        JumpGaugeEffectPool();
    }

    private void JumpGaugeEffectPool()
    {
        jumpGaugeEffectPool = new List<GameObject>();
        for (int i = 0; i < 4; i++)
        {
            jumpGaugeEffectPool.Add(Instantiate(jumpGaugeEffectPre, gameObject.transform));
            jumpGaugeEffectPool[i].SetActive(false);
        }
    }

    public void ShowJumpGaugeEffect(Vector3 uiWorldPos)
    {
        foreach (var item in jumpGaugeEffectPool)
        {
            if (!item.activeSelf)
            {
                item.transform.position = uiWorldPos;
                item.SetActive(true);
                item.GetComponent<JumpGaugeEffect>().Show();
                break;
            }
        }
    }
}

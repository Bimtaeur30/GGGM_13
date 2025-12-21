using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class JumpGaugeUI : MonoBehaviour
{
    [SerializeField] private GameObject jumpGaugeBoxPre;
    private List<GameObject> jumpGaugeBoxPool;
    private PlayerJump _playerjump;

    private void Start()
    {
        _playerjump = YHWGameManager.Instance.Player.GetComponent<PlayerJump>();
        JumpGaugeBoxPool();
        jumpGaugeBoxPool[0].SetActive(true);
        _playerjump._onChargeJumpGauge += JumpGaugeCharge;
        _playerjump._onDeleteJumpGauge += JumpGaugeDelete;
    }

    void JumpGaugeBoxPool()
    {
        jumpGaugeBoxPool = new List<GameObject>();
        for (int i = 0; i < _playerjump.MaxJumpGauge; i++)
        {
            jumpGaugeBoxPool.Add(Instantiate(jumpGaugeBoxPre, gameObject.transform));
            jumpGaugeBoxPool[i].SetActive(false);
        }
    }

    void JumpGaugeCharge()
    {
        for (int i = 0; i < jumpGaugeBoxPool.Count; i++)
        {
            if (!jumpGaugeBoxPool[i].activeSelf)
            {
                jumpGaugeBoxPool[i].SetActive(true);
                break;
            }
        }
    }

    void JumpGaugeDelete()
    {
        for (int i = 0; i < jumpGaugeBoxPool.Count; i++)
        {
            if (jumpGaugeBoxPool[i].activeSelf)
            {
                jumpGaugeBoxPool[i].SetActive(false);
                break;
            }
        }
    }
}

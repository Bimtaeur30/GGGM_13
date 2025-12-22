using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class JumpGaugeUI : MonoBehaviour
{
    [SerializeField] private GameObject jumpGaugeBoxPre;
    [SerializeField] private GameObject jumpGaugeBarPre;
    private List<GameObject> jumpGaugeBoxPool;
    private GameObject jumpGaugeBar;
    private PlayerJump _playerjump;

    private void Start()
    {
        _playerjump = YHWGameManager.Instance.Player.GetComponent<PlayerJump>();
        StartJumpGauge();
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
        JumpGaugeBarOnOff();
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
        JumpGaugeBarOnOff();
    }

    void StartJumpGauge()
    {
        JumpGaugeBoxPool();
        jumpGaugeBoxPool[0].SetActive(true);
        jumpGaugeBar = Instantiate(jumpGaugeBarPre, gameObject.transform);
    }

    void JumpGaugeBarOnOff()
    {
        int temp = 0;
        for (int i = 0; i < jumpGaugeBoxPool.Count; i++)
        {
            if (jumpGaugeBoxPool[i].activeSelf)
            {
                temp += 1;
            }
        }

        if (temp == jumpGaugeBoxPool.Count)
        {
            jumpGaugeBar.SetActive(false);
        }
        else
        {
            jumpGaugeBar.SetActive(true);
        }
    }
}

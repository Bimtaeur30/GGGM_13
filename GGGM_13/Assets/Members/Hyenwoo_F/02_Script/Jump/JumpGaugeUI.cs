using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class JumpGaugeUI : MonoBehaviour
{
    [SerializeField] private List<GameObject> jumpGaugeBoxList;
    //[SerializeField] private GameObject jumpGaugeBarPre;
    //private GameObject jumpGaugeBar;
    private PlayerJump _playerjump;
    private PlayerHP _playerHP;

    private void Start()
    {
        _playerjump = YHWGameManager.Instance.Player.GetComponent<PlayerJump>();
        _playerHP = YHWGameManager.Instance.Player.GetComponent<PlayerHP>();
        StartJumpGauge();
        _playerjump._onChargeJumpGauge += JumpGaugeCharge;
        _playerjump._onDeleteJumpGauge += JumpGaugeDelete;
        _playerHP._onDie += AllGaugeOff;
    }

    void JumpGaugeBoxPool()
    {
        foreach (var item in jumpGaugeBoxList)
        {
            item.SetActive(false);
        }
    }

    void JumpGaugeCharge()
    {
        for (int i = 0; i < jumpGaugeBoxList.Count; i++)
        {
            if (!jumpGaugeBoxList[i].activeSelf)
            {
                jumpGaugeBoxList[i].SetActive(true);
                JumpGaugeEffectManager.Instance.ShowJumpGaugeEffect(jumpGaugeBoxList[i].transform.position);

                break;
            }
        }
        JumpGaugeBarOnOff();
    }

    void JumpGaugeDelete()
    {
        for (int i = jumpGaugeBoxList.Count; i > 0; i--)
        {
            if (jumpGaugeBoxList[i-1].activeSelf)
            {
                jumpGaugeBoxList[i-1].SetActive(false);
                break;
            }
        }
        JumpGaugeBarOnOff();
    }

    void StartJumpGauge()
    {
        JumpGaugeBoxPool();
        jumpGaugeBoxList[0].SetActive(true);
        //jumpGaugeBar = Instantiate(jumpGaugeBarPre, gameObject.transform);
    }

    void JumpGaugeBarOnOff()
    {
        int temp = 0;
        for (int i = 0; i < jumpGaugeBoxList.Count; i++)
        {
            if (jumpGaugeBoxList[i].activeSelf)
            {
                temp += 1;
            }
        }

        if (temp == jumpGaugeBoxList.Count)
        {
            //jumpGaugeBar.SetActive(false);
        }
        else
        {
            //jumpGaugeBar.SetActive(true);
        }
    }

    void AllGaugeOff()
    {
        foreach (var item in jumpGaugeBoxList)
        {
            item.SetActive(false);
        }
        //jumpGaugeBar.SetActive(false);
    }
}

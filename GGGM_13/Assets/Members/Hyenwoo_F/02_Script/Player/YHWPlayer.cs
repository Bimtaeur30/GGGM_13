using System.Collections;
using UnityEngine;

public class YHWPlayer : MonoBehaviour
{
    public PlayerJump JumpCompo { get; private set; }
    public PlayerHP HPCompo { get; private set; }
    public PlayerAnimation AnimCompo { get; private set; }
    public GunFiring FiringCompo { get; private set; }

    private void Awake()
    {
        JumpCompo = GetComponent<PlayerJump>();
        HPCompo = GetComponent<PlayerHP>();
        AnimCompo = GetComponentInChildren<PlayerAnimation>();
        FiringCompo = GetComponentInChildren<GunFiring>();
    }

    public void PlayerSizeDown(float downSize, float time)
    {
        StartCoroutine(SizeDown(downSize, time));
    }

    private IEnumerator SizeDown(float downSize, float time)
    {
        gameObject.transform.localScale = new Vector3(downSize, downSize, 0);
        yield return new WaitForSeconds(time);
        gameObject.transform.localScale = new Vector3(1, 1, 0);
    }
}

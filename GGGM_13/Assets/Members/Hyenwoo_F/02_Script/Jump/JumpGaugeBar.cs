using UnityEngine;

public class JumpGaugeBar : MonoBehaviour
{
    [SerializeField] private Transform _jumpGaugeBar;
    private PlayerJump playerJump;

    private void Start()
    {
        playerJump = YHWGameManager.Instance.Player.GetComponent<PlayerJump>();
    }

    private void Update()
    {
        UpdateBar();
    }

    void UpdateBar()
    {
        float bScale = playerJump.GetTimeNormalize();
        _jumpGaugeBar.localScale = new Vector3(bScale, _jumpGaugeBar.localScale.y, _jumpGaugeBar.localScale.z);
    }
}

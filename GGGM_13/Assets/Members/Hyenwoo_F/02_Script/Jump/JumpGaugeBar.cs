using UnityEngine;
using UnityEngine.UI;

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
        if (bScale >= 0.1)
            _jumpGaugeBar.GetComponent<Image>().fillAmount = bScale;
        else
            _jumpGaugeBar.GetComponent<Image>().fillAmount = 0;
    }
}

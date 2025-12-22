using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJump : MonoBehaviour
{
    [Header("GroundChecker")]
    [SerializeField] private Transform _groundCheckerTrm;
    [SerializeField] private Vector2 _groundCheckerSize;
    [SerializeField] private LayerMask _groundLayer;
    [Header("Jump")]
    [SerializeField] private float jumpPower;
    [SerializeField] private float jumpGaugeChargeTime;
    [field:SerializeField] public int MaxJumpGauge { get; private set; }
    [Header("Particle")]
    [SerializeField] private ParticleSystem _landingParticle;
    private int _currentJumpGauge;
    private Rigidbody2D _rigid;
    private float _timer = 0;
    private bool isGround;
    private bool isJumping;
    private bool isFastLanding = false;

    public event Action _onChargeJumpGauge;
    public event Action _onDeleteJumpGauge;

    private void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _currentJumpGauge = 1;
    }

    private void Update()
    {
        if (isGround == true)
        {
            _timer += Time.deltaTime;
        }

        if (_timer >= jumpGaugeChargeTime)
        {
            JumpGaugeCharge();
            _timer = 0;
        }

        if (Keyboard.current.wKey.wasPressedThisFrame)
        {
            Jump();
        }

        if (Keyboard.current.sKey.wasPressedThisFrame)
        {
            FastLanding();
        }

        if (isGround == true && isJumping == true)
            Landing();
    }

    private void FixedUpdate()
    {
        isGround = GroundCheck();
    }

    private void JumpGaugeCharge()
    {
        _onChargeJumpGauge?.Invoke();
        _currentJumpGauge += 1;
        _currentJumpGauge = Mathf.Clamp(_currentJumpGauge, 0, MaxJumpGauge);
    }

    private void Jump()
    {
        if (_currentJumpGauge > 0 && isGround == true)
        {
            _rigid.AddForceY(jumpPower, ForceMode2D.Impulse);
            _onDeleteJumpGauge?.Invoke();
            _currentJumpGauge -= 1;
            _timer = 0;
            StartCoroutine(OnIsJumping());
        }
    }

    private void FastLanding()
    {
        if (_currentJumpGauge > 0 && isGround == false && isFastLanding == false)
        {
            _rigid.AddForceY(-10, ForceMode2D.Impulse);
            _onDeleteJumpGauge?.Invoke();
            isFastLanding = true;
            _currentJumpGauge -= 1;
            _timer = 0;
        }
    }

    private void Landing()
    {
        isJumping = false;
        isFastLanding = false;
        _landingParticle.Play();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(_groundCheckerTrm.position, _groundCheckerSize);
    }

    private bool GroundCheck()
    {
        Collider2D collider = Physics2D.OverlapBox(_groundCheckerTrm.position, _groundCheckerSize, 0, _groundLayer);
        return collider;
    }

    public float GetTimeNormalize()
    {
        return _timer / jumpGaugeChargeTime;
    }

    private IEnumerator OnIsJumping()
    {
        yield return new WaitForSeconds(0.2f);
        isJumping = true;
    }
}

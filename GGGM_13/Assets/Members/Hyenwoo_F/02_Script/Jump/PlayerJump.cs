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
    [SerializeField] private ParticleSystem _runParticle;
    [Header("Extra Setting")]
    [SerializeField] private float _extraGravity = 30f;
    [SerializeField] private float _gravityDelay = 0.15f;
    private int _currentJumpGauge;
    public Rigidbody2D RigidCompo { get; private set; }
    private float _timer = 0;
    public bool IsGround { get; private set; }
    public bool IsJumping { get; private set; }
    private bool isFastLanding = false;
    private PlayerHP playerHP;
    private YHWPlayer player;
    private float _timeInAir;

    public event Action _onChargeJumpGauge;
    public event Action _onDeleteJumpGauge;

    private void Awake()
    {
        RigidCompo = GetComponent<Rigidbody2D>();
        playerHP = GetComponent<PlayerHP>();
        player = GetComponent<YHWPlayer>();
    }

    private void Start()
    {
        _currentJumpGauge = 1;
        _runParticle.Play();
        playerHP._onDie += () => _runParticle.Stop();
    }

    private void Update()
    {
        if (IsGround == true && !player.AnimCompo.AnimCompo.GetBool("IsDie"))
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

        if (IsGround == true && IsJumping == true)
            Landing();

        CalculateTimeInAir();
    }

    private void CalculateTimeInAir()
    {
        if (!IsGround)
            _timeInAir += Time.deltaTime;
        else
            _timeInAir = 0f;
    }

    private void FixedUpdate()
    {
        IsGround = GroundCheck();
        ApplyExtraGravity();
    }

    private void JumpGaugeCharge()
    {
        _onChargeJumpGauge?.Invoke();
        _currentJumpGauge += 1;
        _currentJumpGauge = Mathf.Clamp(_currentJumpGauge, 0, MaxJumpGauge);
    }

    private void Jump()
    {
        if (_currentJumpGauge > 0 && IsGround == true && !player.AnimCompo.AnimCompo.GetBool("IsDie"))
        {
            RigidCompo.AddForceY(jumpPower, ForceMode2D.Impulse);
            _onDeleteJumpGauge?.Invoke();
            _currentJumpGauge -= 1;
            _timer = 0;
            _runParticle.Stop();
            SoundManager.Instance.PlaySound(SFX.PlayerJump);
            StartCoroutine(OnIsJumping());
        }
    }

    private void FastLanding()
    {
        if (_currentJumpGauge > 0 && IsGround == false && isFastLanding == false)
        {
            RigidCompo.AddForceY(-10, ForceMode2D.Impulse);
            _onDeleteJumpGauge?.Invoke();
            isFastLanding = true;
            _currentJumpGauge -= 1;
            _timer = 0;
        }
    }

    private void Landing()
    {
        IsJumping = false;
        isFastLanding = false;
        _landingParticle.Play();
        _runParticle.Play();
        SoundManager.Instance.PlaySound(SFX.PlayerLanding);
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
        IsJumping = true;
    }

    private void ApplyExtraGravity()
    {
        if (_timeInAir > _gravityDelay)
        {
            RigidCompo.AddForceY(-_extraGravity);
        }
    }
}
